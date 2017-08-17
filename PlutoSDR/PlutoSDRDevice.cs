using System;
using SDRSharp.Radio;
using System.Runtime.InteropServices;
using System.Threading;
using iio;
using System.Windows.Forms;

namespace SDRSharp.PlutoSDR
{
    public sealed class PlutoSDRDevice : IDisposable
    {
        private const uint DefaultFrequency = 405500000U;
        private const int DefaultSamplerate = 2500000;
        private const uint MinFrequency = 237500000;
        private const uint MaxFrequency = 3800000000;
        private const int MinBandwidth = 1500000;
        private const int MaxBandwidth = 28000000;
        private const uint SampleTimeoutMs = 1000;
        private const uint NumBuffers = 32;
        
        private static object syncLock = new object();
        private string DeviceName = "PlutoSDR";
        private Device _dev;
        private Context _ctx;
        private IOBuffer _buf;
        private Channel _rx0_i;
        private Channel _rx0_q;
        private long _centerFrequency = DefaultFrequency;
        private double _sampleRate = DefaultSamplerate;
        private int _bandwidth;
        private bool _RXConfigured = false;
        private string _fpga_path = Utils.GetStringSetting("PlutoSDRFPGA", "");
        private int _manualGain = Utils.GetIntSetting("PlutoSDRManualGain", 20);
        private GCHandle _gcHandle;
        private UnsafeBuffer _iqBuffer;
        private unsafe Complex* _iqPtr;
        private bool _isStreaming;
        private string _devSpec;
        private readonly SamplesAvailableEventArgs _eventArgs = new SamplesAvailableEventArgs();
        private static uint _readLength = 4 * 1024;
        private Thread _sampleThread = null;
        private static bool _xb200_enabled = Utils.GetBooleanSetting("PlutoSDRXB200Enabled");

        private UnsafeBuffer _samplesBuffer;
        private unsafe Int16* _samplesPtr;
        
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
                _sampleRate = value;
               if (_dev != null)
                {
                    double actual;
                    //if (0 == NativeMethods.PlutoSDR_set_sample_rate(_dev, PlutoSDR_module.PlutoSDR_MODULE_RX, _sampleRate, out actual))
                    //    _sampleRate = actual;
                    //adjustReadLength();
                    //uint tmp = 0;
                    //if (_bandwidth == 0)
                    //    NativeMethods.PlutoSDR_set_bandwidth(_dev, PlutoSDR_module.PlutoSDR_MODULE_RX, (uint)(_sampleRate * 0.75), out tmp);
                }
                OnSampleRateChanged();
            }
        }

        private void adjustReadLength()
        {
            lock (syncLock)
            {
                /*if (_sampleRate <= 1000000)
                    _readLength = 4096U;
                else if (_sampleRate <= 10000000)
                    _readLength = 16384U;
                else
                    _readLength = 32768U;*/
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
                if (_bandwidth != 0)
                    return _bandwidth;
               if (_dev != null)
                {
                    uint tmp;
                    //if (0 == NativeMethods.PlutoSDR_get_bandwidth(_dev, PlutoSDR_module.PlutoSDR_MODULE_RX, out tmp))
                    //    return (int) tmp;
                }
                return Math.Min(MaxBandwidth, Math.Max((int)(0.75 * _sampleRate), MinBandwidth));
            }

            set
            {
                _bandwidth = value;
               if (_dev != null)
                {
                    uint tmp;
                    //if (value == 0)
                    //    NativeMethods.PlutoSDR_set_bandwidth(_dev, PlutoSDR_module.PlutoSDR_MODULE_RX, (uint) (0.75 * _sampleRate), out tmp);
                    //else
                    //    NativeMethods.PlutoSDR_set_bandwidth(_dev, PlutoSDR_module.PlutoSDR_MODULE_RX, (uint) value, out tmp);
                }
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
               if (_dev != null)
                {
                    IIOHelper.SetAttribute(_dev, "altvoltage0", "frequency", value);
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


        public PlutoSDRDevice(string serial = "")
        {
            string devspec = "";
            if (serial != "")
                devspec = String.Format("*:serial={0}", serial);

//            var rv = NativeMethods.PlutoSDR_open(out _dev, devspec);
//            if (rv != 0)
//                throw new ApplicationException(String.Format("Cannot open PlutoSDR device. Is the device locked somewhere?. {0}", NativeMethods.PlutoSDR_strerror(rv)));
//            _devSpec = devspec;
//            _gcHandle = GCHandle.Alloc(this);
//            if (serial == "")
//                if ((rv = NativeMethods.PlutoSDR_get_serial(_dev, out serial)) != 0)
//                    throw new ApplicationException(String.Format("PlutoSDR_get_serial() error. {0}", NativeMethods.PlutoSDR_strerror(rv)));
//            _serial = serial;
//            DeviceName = String.Format("PlutoSDR SN#{0}", serial);
//            NativeMethods.PlutoSDR_close(_dev);
//            _dev = IntPtr.Zero;
//#if DEBUG
//            NativeMethods.PlutoSDR_log_set_verbosity(PlutoSDR_log_level.PlutoSDR_LOG_LEVEL_VERBOSE);
//#endif
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

        private unsafe void ReceiveSamples_sync()
        {
            int status = 0;
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

                        byte[] samplesI = _rx0_i.read(_buf);
                        byte[] samplesQ = _rx0_q.read(_buf);

                        const float scale = 1.0f / 2048.0f;
                                                
                        var ptrIq = _iqPtr;
                        for (int i = 0; i < _readLength; i++)
                        {
                            int sampleOffset = i * 2;
                            var sampleI = (samplesI[sampleOffset + 1] << 8) + samplesI[sampleOffset];
                            var sampleQ = (samplesQ[sampleOffset + 1] << 8) + samplesQ[sampleOffset];

                            ptrIq->Real = (((( sampleI ) + 2048) % 4096) - 2048) * scale;
                            ptrIq->Imag = (((( sampleQ ) + 2048) % 4096) - 2048) * scale;
                            ptrIq++;
                        }
                        ComplexSamplesAvailable(_iqPtr, _iqBuffer.Length);
                    }
                    catch
                    {
                        break;
                    }
                    lock (syncLock)
                    {
                        new_len = _readLength;
                    }
                }
              
            }
        }

        public unsafe void Start()
        {
            int error;
            if (_isStreaming)
                throw new ApplicationException("Start() Already running");
            if (_dev == null)
            {
                //MessageBox.Show("Connecting!");
                _ctx = new iio.Context("ip:192.168.2.1");
                _dev = _ctx.get_device("ad9361-phy");
            }
            if (_dev == null)
                throw new ApplicationException("Cannot open device");


            IIOHelper.SetAttribute(_dev, "altvoltage0", "frequency", 103000000L);
            IIOHelper.SetAttribute(_dev, "voltage0", "sampling_frequency", 1000000L);

            IIOHelper.SetAttribute(_dev, "voltage0", "gain_control_mode", "manual");
            IIOHelper.SetAttribute(_dev, "voltage1", "gain_control_mode", "manual");



            Device lpc = _ctx.get_device("cf-ad9361-lpc");

            if (lpc == null)
            {
                throw new ApplicationException("Device cf-ad9361-lpc not found!");
            }

            _rx0_i = IIOHelper.FindChannel(lpc, "voltage0");
            _rx0_q = IIOHelper.FindChannel(lpc, "voltage1");

            _rx0_i.enable();
            _rx0_q.enable();

            adjustReadLength();

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
                int error;
                _isStreaming = false;
            }
            
            if (_sampleThread != null)
            {
                if (_sampleThread.ThreadState == ThreadState.Running)
                    _sampleThread.Join();
                _sampleThread = null;
            }

           if (_dev != null)
            {
                _dev = null;
            }
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
