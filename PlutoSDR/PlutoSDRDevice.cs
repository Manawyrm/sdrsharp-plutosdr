using System;
using SDRSharp.Radio;
using System.Runtime.InteropServices;
using System.Threading;
using iio;
using System.Windows.Forms;
using System.Reflection;

namespace SDRSharp.PlutoSDR
{
    public sealed class PlutoSDRDevice : IDisposable
    {
        private const uint DefaultFrequency = 405500000U;
        private const int DefaultSamplerate = 1000000;
        private const uint MinFrequency = 237500000;
        private const uint MaxFrequency = 3800000000;
        private const int MinBandwidth = 1500000;
        private const int MaxBandwidth = 28000000;
        private const uint SampleTimeoutMs = 1000;

        private static object syncLock = new object();
        private string DeviceName = "PlutoSDR";
        private Device _dev;
        private Context _ctx;
        private IOBuffer _buf;
        private Channel _rx0_i;
        private Channel _rx0_q;
        private long _centerFrequency = DefaultFrequency;
        private long _sampleRate = DefaultSamplerate;
        private long _bandwidth;
        private string _gainControlMode = Utils.GetStringSetting("PlutoSDRGainControlMode", "manual");
        private bool _RXConfigured = false;
        private int _manualGain = Utils.GetIntSetting("PlutoSDRManualGain", 20);
        private GCHandle _gcHandle;
        private UnsafeBuffer _iqBuffer;
        private unsafe Complex* _iqPtr;
        public bool _isStreaming;
        private readonly SamplesAvailableEventArgs _eventArgs = new SamplesAvailableEventArgs();
        private static uint _readLength = 512 * 1024;
        private Thread _sampleThread = null;
        private PlutoSDRIO _plutoSDRIO;
        private PlutoSDRControllerDialog _gui;

        public uint Index
        {
            get
            {
                return 0;
            }
        }

        public string Name
        {
            get
            {
                return DeviceName;
            }
        }

        public int ManualGain
        {
            get
            {
                return _manualGain;
            }
            set
            {
                _manualGain = value;
                if (_dev != null)
                    IIOHelper.SetAttribute(_dev, "voltage0", "hardwaregain", value);
            }
        }

        public double SampleRate
        {
            get
            {
                return _sampleRate;
            }
            set
            {
                _sampleRate = (long)value;
                if (_dev != null)
                {
                    try
                    {
                        IntPtr dev = (IntPtr) NativeMethods.GetInstanceField(typeof(Device), _dev, "dev");

                        //FIXME: return value of set_bb_rate should be checked!
                        int retVal = NativeMethods.ad9361_set_bb_rate(dev, (uint)value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't set sample rate of " + value.ToString() + "!\n" + ex.Message, "Unsupported sample rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Bandwidth = (int) (value * 1.25);
                    configureReadLength();
                }
                OnSampleRateChanged();
            }
        }

        public void configureReadLength()
        {
            if (!IsStreaming)
            {
                _readLength = (uint)(((long)_sampleRate / 20));
                _gui.bufferReadSizeLabel.Text = _readLength.ToString() + " Bytes";
            }
        }

        public event EventHandler SampleRateChanged;

        public void OnSampleRateChanged()
        {
            if (SampleRateChanged != null)
                SampleRateChanged(this, EventArgs.Empty);
        }

        public int Bandwidth
        {
            get
            {
                return (int)_bandwidth;
            }

            set
            {
                _bandwidth = value;
                _gui.bandwidthLabel.Text = _bandwidth.ToString() + " Hz";
                if (_dev != null)
                {
                    IIOHelper.SetAttribute(_dev, "voltage0", "rf_bandwidth", value);
                }
            }
        }

        public string RSSI
        {
            get
            {
                return IIOHelper.GetAttributeString(_dev, "voltage0", "rssi");
            }
        }

        public string GainControlMode
        {
            get
            {
                return _gainControlMode;
            }
            set
            {
                if (value == "manual" || value == "slow_attack")
                {
                    _gainControlMode = value;
                }
                IIOHelper.SetAttribute(_dev, "voltage0", "gain_control_mode", value);
                IIOHelper.SetAttribute(_dev, "voltage1", "gain_control_mode", value);
            }
        }


        public long Frequency
        {
            get
            {
                return _centerFrequency;
            }
            set
            {
                _centerFrequency = value;
                if (_dev != null)
                {
                    try
                    {
                        IIOHelper.SetAttribute(_dev, "altvoltage0", "frequency", _centerFrequency);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't set frequency to " + value.ToString() + "!\n" + ex.Message, "Unsupported LO frequency", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
				}
            }
        }

        public bool IsStreaming
        {
            get
            {
                return _isStreaming;
            }
        }

        public PlutoSDRDevice(PlutoSDRIO plutoSDRIO)
        {
            _plutoSDRIO = plutoSDRIO;
            _gui = _plutoSDRIO.GUI;
        }

        ~PlutoSDRDevice()
        {
            Dispose();
        }

        public void Dispose()
        {
            Stop();
            if (_gcHandle.IsAllocated)
            {
                _gcHandle.Free();
            }
            _dev = null;
            GC.SuppressFinalize(this);
        }

        public event SamplesAvailableDelegate SamplesAvailable;
        const float scale = 1.0f / 32768.0f;
        byte[] samplesI;
        byte[] samplesQ;

        private unsafe void ReceiveSamples_sync()
        {
            int status = 0;

            float[] lut = new float[0x10000];
            for (UInt16 i = 0x0000; i < 0xFFFF; i++)
            {
                lut[i] = ((((i & 0xFFFF) + 32768) % 65536) - 32768) * scale; 
            }
            while (_isStreaming)
            {
                uint cur_len, new_len;
                lock (syncLock)
                {
                    cur_len = new_len = _readLength;
                }
                if (_iqBuffer == null || _iqBuffer.Length != cur_len)
                {
                    _iqBuffer = UnsafeBuffer.Create((int)cur_len, sizeof(Complex));
                    _iqPtr = (Complex*)_iqBuffer;
                }

                lock (syncLock)
                {
                    _RXConfigured = true;
                }
                while (status == 0)
                {
                    try
                    {
                        _buf.refill();

                        samplesI = _rx0_i.read(_buf);
                        samplesQ = _rx0_q.read(_buf);

                        var ptrIq = _iqPtr;
                        for (int i = 0; i < _readLength; i++)
                        {
                            int sampleOffset = (i * 2);

                            UInt16 sampleI = (UInt16)((samplesI[sampleOffset + 1] << 8) + samplesI[sampleOffset]);
                            UInt16 sampleQ = (UInt16)((samplesQ[sampleOffset + 1] << 8) + samplesQ[sampleOffset]);

                            ptrIq->Real = lut[sampleI];
                            ptrIq->Imag = lut[sampleQ];
                            ptrIq++;
                        }
                        if (_isStreaming)
                        {
                            ComplexSamplesAvailable(_iqPtr, _iqBuffer.Length);
                        }
                    }
                    catch
                    {
                        break;
                    }
                    lock (syncLock)
                    {
                        new_len = _readLength;
                    }

                    if (_isStreaming == false)
                    {
                        status = 1;
                    }
                }

            }
        }

        public bool createContext()
        {
            _gui.deviceUriTextbox.Enabled = false;
            _gui.connectButton.Enabled = false;

            try
            {
                //MessageBox.Show(_gui.deviceUriTextbox.Text);
                _ctx = new iio.Context(_gui.deviceUriTextbox.Text);

                _gui.libiioVersionLabel.Text = _ctx.backend_version.git_tag;
                _dev = _ctx.get_device("ad9361-phy");

                if (_dev == null)
                    throw new ApplicationException("Cannot open device ad9361-phy");

                Utils.SaveSetting("PlutoSDRURI", _gui.deviceUriTextbox.Text);

                _gui.receiverPanel.Enabled = true;

                _gui.contextDetailsLabel.Text = _ctx.description;


                return true;
            }
            catch (Exception ex)
            {
                _gui.deviceUriTextbox.Enabled = true;
                _gui.connectButton.Enabled = true;
                throw ex;
            }

        }

        public void configureReceiver()
        {
            this.Frequency = _centerFrequency;
            this.SampleRate = _sampleRate;

            this.GainControlMode = _gainControlMode;
            this.ManualGain = _manualGain;
        }
        public unsafe void Start()
        {
            if (_isStreaming)
                throw new ApplicationException("Start() Already running");

            PlutoSDRControllerDialog gui = _plutoSDRIO.GUI;
            _gui.samplerateComboBox.Enabled = false;

            if (_dev == null)
            {
                createContext();
            }

            configureReceiver();

            Device lpc = _ctx.get_device("cf-ad9361-lpc");

            if (lpc == null)
            {
                throw new ApplicationException("Device cf-ad9361-lpc not found!");
            }

            _rx0_i = IIOHelper.FindChannel(lpc, "voltage0");
            _rx0_q = IIOHelper.FindChannel(lpc, "voltage1");

            _rx0_i.enable();
            _rx0_q.enable();

            if (_buf != null)
            {
                _buf.Dispose();
            }
            _buf = new IOBuffer(lpc, _readLength, false);
            if (_buf == null)
                throw new ApplicationException("Could not initialize I/Q sample buffer");

            // new sync interface
            _sampleThread = new Thread(ReceiveSamples_sync);
            _sampleThread.Name = "PlutoSDR_samples_rx";
            _sampleThread.Priority = ThreadPriority.Highest;
            _isStreaming = true;
            _sampleThread.Start();
            bool ready = false;
            while (!ready)
            {
                lock (syncLock)
                {
                    ready = _RXConfigured;
                }
            }

        }

        public void Stop()
        {
            if (_isStreaming)
            {
                _isStreaming = false;
            }

            if (_sampleThread != null)
            {
                if (_sampleThread.ThreadState == ThreadState.Running)
                    _sampleThread.Join();

                _sampleThread = null;
            }

            PlutoSDRControllerDialog gui = _plutoSDRIO.GUI;
            _gui.samplerateComboBox.Enabled = true;
        }

        private unsafe void ComplexSamplesAvailable(Complex* buffer, int length)
        {
            if (SamplesAvailable != null)
            {
                _eventArgs.Buffer = buffer;
                _eventArgs.Length = length;
                SamplesAvailable(this, _eventArgs);
            }
        }

        private sealed class FrequencyRange
        {
            private long _min, _max;
            public FrequencyRange(long min, long max)
            {
                _min = min;
                _max = max;
            }

            public long Min
            {
                get { return _min; }
                set { _min = value; }
            }

            public long Max
            {
                get { return _max; }
                set { _max = value; }
            }

            public bool contains(long frequency)
            {
                return (Min <= frequency) && (frequency <= Max);
            }
        }
    }

    public delegate void SamplesAvailableDelegate(object sender, SamplesAvailableEventArgs e);

    public unsafe sealed class SamplesAvailableEventArgs : EventArgs
    {
        public int Length { get; set; }
        public Complex* Buffer { get; set; }
    }
}
