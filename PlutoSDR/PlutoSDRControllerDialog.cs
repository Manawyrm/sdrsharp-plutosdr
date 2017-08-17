using System;
using System.Globalization;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;
using iio;

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
            InitBandwidths();
            var devices = DeviceDisplay.GetActiveDevices();
            deviceComboBox.Items.Clear();
            if (devices != null)
                deviceComboBox.Items.AddRange(devices);

            //samplerateComboBox.SelectedIndex = Utils.GetIntSetting("PlutoSDRSampleRate", 1);
            samplerateComboBox.SelectedIndex = 2;
            // FIXME!!!


            //samplingModeComboBox.SelectedIndex = Utils.GetIntSetting("PlutoSDRSamplingMode", (int) PlutoSDR_sampling.PlutoSDR_SAMPLING_INTERNAL);
            rxVga1GainTrackBar.Value = Utils.GetIntSetting("PlutoSDRManualGain", 20);
            bandwidthComboBox.SelectedIndex = Utils.GetIntSetting("PlutoSDRBandwidth", 0);

            //labelVersion.Text = "libPlutoSDR " + NativeMethods.PlutoSDR_version().describe;

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
            /*for (int i = 40; i > 0; i--)
                samplerateComboBox.Items.Add(String.Format("{0} MSPS", i));
            for (int i = 900; i > 0; i -= 300)
                samplerateComboBox.Items.Add(String.Format("0.{0} MSPS", i));
            samplerateComboBox.Items.Add("0.200 MSPS");
            samplerateComboBox.Items.Add("0.160 MSPS");*/
            samplerateComboBox.Items.Add("2.5 MSPS");
            samplerateComboBox.Items.Add("2 MSPS");
            samplerateComboBox.Items.Add("1 MSPS");
        }

        private void InitBandwidths()
        {
            bandwidthComboBox.Items.Clear();
            bandwidthComboBox.DisplayMember = "Text";
            bandwidthComboBox.ValueMember = "Value";
            bandwidthComboBox.Items.Add(new ComboboxItem("auto", 0));
            bandwidthComboBox.Items.Add(new ComboboxItem("28 MHz", 28000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("20 MHz", 20000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("14 MHz", 14000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("12 MHz", 12000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("10 MHz", 10000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("8.75 MHz", 8750000));
            bandwidthComboBox.Items.Add(new ComboboxItem("7 MHz", 7000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("6 MHz", 6000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("5.5 MHz", 5500000));
            bandwidthComboBox.Items.Add(new ComboboxItem("5 MHz", 5000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("3.84 MHz", 3840000));
            bandwidthComboBox.Items.Add(new ComboboxItem("3 MHz", 3000000));
            bandwidthComboBox.Items.Add(new ComboboxItem("2.75 MHz", 2750000));
            bandwidthComboBox.Items.Add(new ComboboxItem("2.5 MHz", 2500000));
            bandwidthComboBox.Items.Add(new ComboboxItem("1.75 MHz", 1750000));
            bandwidthComboBox.Items.Add(new ComboboxItem("1.5 MHz", 1500000));
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
                deviceComboBox.Enabled = Initialized && !_owner.Device.IsStreaming;

                if (Initialized && !_owner.Device.IsStreaming)
                {
                    var devices = DeviceDisplay.GetActiveDevices();
                    deviceComboBox.Items.Clear();
                    if (devices != null)
                    {
                        deviceComboBox.Items.AddRange(devices);

                        for (var i = 0; i < devices.Length; i++)
                        {
                            if (devices[i].Index == ((DeviceDisplay)(deviceComboBox.Items[i])).Index)
                            {
                                _initialized = false;
                                deviceComboBox.SelectedIndex = i;
                                _initialized = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            deviceComboBox.Enabled = Initialized && !_owner.Device.IsStreaming;
        }

        private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialized)
            {
                return;
            }
            var deviceDisplay = (DeviceDisplay) deviceComboBox.SelectedItem;
            if (deviceDisplay != null)
            {
                try
                {
                    _owner.SelectDevice(deviceDisplay.Serial);
                }
                catch (Exception ex)
                {
                    deviceComboBox.SelectedIndex = -1;
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Utils.SaveSetting("PlutoSDRSampleRate", samplerateComboBox.SelectedIndex);
        }

        public void ConfigureGUI()
        {
            if (!Initialized)
                return;

            PlutoSDRTypeLabel.Text = _owner.Device.Name;

            for (var i = 0; i < deviceComboBox.Items.Count; i++)
            {
                var deviceDisplay = (DeviceDisplay) deviceComboBox.Items[i];
                /*if (deviceDisplay.Serial == _owner.Device.Serial)
                {
                    deviceComboBox.SelectedIndex = i;
                    break;
                }*/
            }
        }

        public void ConfigureDevice()
        {
            samplerateComboBox_SelectedIndexChanged(null, null);
            bandwidthComboBox_SelectedIndexChanged(null, null);
        }
        

        private void bandwidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initialized)
                return;
            Utils.SaveSetting("PlutoSDRBandwidth", bandwidthComboBox.SelectedIndex);
            try
            {
                _owner.Device.Bandwidth = (bandwidthComboBox.SelectedItem as ComboboxItem).Value;
            }
            catch
            {
                _owner.Device.Bandwidth = 0;
            }
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

        private void PlutoSDRControllerDialog_Load(object sender, EventArgs e)
        {

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
    }

    public class DeviceDisplay
    {
        public int Index { get; private set; }
        public string Name { get; set; }
        public string Serial { get; private set; }
        public int Bus { get; set; }
        public int Address { get; set; }
        public string Backend { get; set; }

        public unsafe static DeviceDisplay[] GetActiveDevices()
        {
            IntPtr _tmp;
            DeviceDisplay[] result = new DeviceDisplay[1];

            try
            {
                Context iioCtx = new iio.Context("ip:192.168.2.1");

                if (iioCtx.devices.Count > 0)
                {
                    string name = String.Format("PlutoSDR (ip) @ 192.168.2.1");
                    result[0] = new DeviceDisplay { Index = 0, Name = name };
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
