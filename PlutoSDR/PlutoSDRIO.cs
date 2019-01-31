using System;
using System.Windows.Forms;
using System.ComponentModel;

using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.PlutoSDR
{
    public class PlutoSDRIO : IFrontendController, IIQStreamController, IDisposable, ISampleRateChangeSource, IFloatingConfigDialogProvider, ITunableSource, IControlAwareObject, ISpectrumProvider
    {
        private const string _displayName = "PlutoSDR";
        private readonly PlutoSDRControllerDialog _gui;
        private PlutoSDRDevice _PlutoSDRDevice;
        private long _frequency;
        private double _frequencyCorrection;
        private SDRSharp.Radio.SamplesAvailableDelegate _callback;
        public event EventHandler SampleRateChanged;

        public PlutoSDRIO()
        {
            _gui = new PlutoSDRControllerDialog(this);
        }

        ~PlutoSDRIO()
        {
            Dispose();
        }

        public void Dispose()
        {
            Close();
            if (_gui != null)
            {
                _gui.Close();
                _gui.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public PlutoSDRDevice Device
        {
            get
            {
                return _PlutoSDRDevice;
            }
        }

        public PlutoSDRControllerDialog GUI
        {
            get
            {
                return _gui;
            }
        }

        public void Open()
        {
            Close();
            _PlutoSDRDevice = new PlutoSDRDevice(this);
            _PlutoSDRDevice.SamplesAvailable += PlutoSDRDevice_SamplesAvailable;
            _PlutoSDRDevice.SampleRateChanged += PlutoSDRDevice_SampleRateChanged;
            _gui.ConfigureGUI();
            _gui.ConfigureDevice();
        }

        public void Close()
        {
            if (_PlutoSDRDevice == null)
                return;
            _PlutoSDRDevice.SamplesAvailable -= PlutoSDRDevice_SamplesAvailable;
            _PlutoSDRDevice.SampleRateChanged -= PlutoSDRDevice_SampleRateChanged;
            _PlutoSDRDevice.Dispose();
            _PlutoSDRDevice = null;
        }

        private void PlutoSDRDevice_SampleRateChanged(object sender, EventArgs e)
        {
            if (SampleRateChanged != null)
                SampleRateChanged(this, EventArgs.Empty);
        }

        public void Start(SDRSharp.Radio.SamplesAvailableDelegate callback)
        {
            if (_PlutoSDRDevice == null)
                throw new ApplicationException("No device selected");
            _callback = callback;
            _PlutoSDRDevice.Start();
        }

        public void Stop()
        {
            if (_PlutoSDRDevice != null)
            {
                _PlutoSDRDevice.Stop();
            }
        }

        public bool IsSoundCardBased
        {
            get
            {
                return false;
            }
        }

        public string SoundCardHint
        {
            get
            {
                return string.Empty;
            }
        }

        public void ShowSettingGUI(IWin32Window parent)
        {
            if (this._gui.IsDisposed)
                return;
            _gui.Show();
            _gui.Activate();
        }

        public void HideSettingGUI()
        {
            if (_gui.IsDisposed)
                return;
            _gui.Hide();
        }

        public double Samplerate
        {
            get
            {
                if (_PlutoSDRDevice != null)
                    return _PlutoSDRDevice.SampleRate;
                else
                    return 0.0;
            }
        }

        public long Frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                if (this._PlutoSDRDevice == null)
                    return;
                this._PlutoSDRDevice.Frequency = (long)(value * (1.0 + this._frequencyCorrection * 1E-06));
                this._frequency = value;
            }
        }

        public double FrequencyCorrection
        {
            get
            {
                return this._frequencyCorrection;
            }
            set
            {
                this._frequencyCorrection = value;
                this.Frequency = this._frequency;
            }
        }

        private unsafe void PlutoSDRDevice_SamplesAvailable(object sender, SamplesAvailableEventArgs e)
        {
            _callback(this, e.Buffer, e.Length);
        }

        public float UsableSpectrumRatio
        {
            get
            {
                // TODO: should I set it to 0.8f instead?
                return 1.0f;
            }
        }

        bool ITunableSource.CanTune
        {
            get
            {
                return true;
            }
        }

        long ITunableSource.MinimumTunableFrequency
        {
            get
            {
                return _PlutoSDRDevice.MinFrequency;
            }
        }
        long ITunableSource.MaximumTunableFrequency
        {
            get
            {
                return _PlutoSDRDevice.MaxFrequency;
            }
        }

        public void SetControl(object control)
        {
            this._gui.Control = (ISharpControl)control;
        }
    }
}
