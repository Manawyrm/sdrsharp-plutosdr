using System;
using System.Globalization;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;
using iio;
using System.Diagnostics;

namespace SDRSharp.PlutoSDR
{
    public partial class PlutoSDRControllerDialog : Form
    {
        private readonly PlutoSDRIO _owner;
        private bool _initialized;

        public PlutoSDRControllerDialog(PlutoSDRIO owner)
        {
            InitializeComponent();
        
            _owner = owner;

            InitSampleRates();

            agcEnabledCheckBox.Checked = (Utils.GetStringSetting("PlutoSDRGainControlMode", "manual") != "manual");
            deviceUriTextbox.Text = Utils.GetStringSetting("PlutoSDRURI", "ip:192.168.2.1");

            samplerateComboBox.SelectedIndex = Utils.GetIntSetting("PlutoSDRSampleRate2", 1);
            //samplingModeComboBox.SelectedIndex = Utils.GetIntSetting("PlutoSDRSamplingMode", (int) PlutoSDR_sampling.PlutoSDR_SAMPLING_INTERNAL);
            rxVga1GainTrackBar.Value = Utils.GetIntSetting("PlutoSDRManualGain", 20);
            rxVga1gainLabel.Text = rxVga1GainTrackBar.Value + " dB";

            _initialized = true;
        }

        private bool Initialized
        {
            get
            {
                return _initialized && _owner.Device != null;
            }
        }

        private void InitSampleRates()
        {
            for (int i = 5; i > 0; i--)
            {
                samplerateComboBox.Items.Add(String.Format("{0} MSPS", i));
            }
            samplerateComboBox.Items.Add("0.7 MSPS");
            samplerateComboBox.Items.Add("0.521 MSPS");

            for (int i = 6; i < 20; i++)
            {
                samplerateComboBox.Items.Add(String.Format("{0} MSPS (not supported!)", i));
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlutoSDRControllerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void PlutoSDRControllerDialog_VisibleChanged(object sender, EventArgs e)
        {
            refreshTimer.Enabled = Visible;
            if (Visible)
            {
                if (Initialized && !_owner.Device.IsStreaming)
                {
                }
            }
        }

        private void samplerateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                return;
            }
            var samplerateString = samplerateComboBox.Items[samplerateComboBox.SelectedIndex].ToString().Split(' ')[0];
            var sampleRate = double.Parse(samplerateString, CultureInfo.InvariantCulture);
            _owner.Device.SampleRate = (uint) (sampleRate * 1000000.0);

            Utils.SaveSetting("PlutoSDRSampleRate2", samplerateComboBox.SelectedIndex);
        }

        public void ConfigureGUI()
        {
            if (!Initialized)
                return;
        }

        public void ConfigureDevice()
        {
            samplerateComboBox_SelectedIndexChanged(null, null);
        }
        
        private class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboboxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        public ISharpControl Control
        {
            get;
            set;
        }
        

        private void rxVga1GainTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                return;
            }
            _owner.Device.ManualGain = rxVga1GainTrackBar.Value;
            rxVga1gainLabel.Text = rxVga1GainTrackBar.Value + " dB";
            Utils.SaveSetting("PlutoSDRManualGain", rxVga1GainTrackBar.Value);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                return;
            }
            if (!_owner.Device.IsStreaming)
            {
                return;
            }

            rssiLabel.Text = _owner.Device.RSSI.ToString();
        }

        private void versionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Manawyrm/sdrsharp-plutosdr");
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            /* Try to connect to the SDR - we set the timeout to a low value and then 
             * open a context to the specified URI */
            try
            {
                _owner.Device.createContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agcEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (agcEnabledCheckBox.Checked)
            {
                rxVga1GainTrackBar.Enabled = false;
                rxVga1gainLabel.Enabled = false;
                label6.Enabled = false;

                if (_owner.Device != null)
                {
                    _owner.Device.GainControlMode = "slow_attack";
                    Utils.SaveSetting("PlutoSDRGainControlMode", _owner.Device.GainControlMode);
                }
            }
            else
            {
                rxVga1GainTrackBar.Enabled = true;
                rxVga1gainLabel.Enabled = true;
                label6.Enabled = true;

                if (_owner.Device != null)
                {
                    _owner.Device.GainControlMode = "manual";
                    Utils.SaveSetting("PlutoSDRGainControlMode", _owner.Device.GainControlMode);
                }
            }
        }

    }
}
