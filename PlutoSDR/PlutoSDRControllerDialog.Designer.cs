namespace SDRSharp.PlutoSDR
{
    partial class PlutoSDRControllerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.samplerateComboBox = new System.Windows.Forms.ComboBox();
            this.PlutoSDRTypeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.samplingModeComboBox = new System.Windows.Forms.ComboBox();
            this.rxVga1GainTrackBar = new System.Windows.Forms.TrackBar();
            this.rxVga1gainLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fpgaOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bandwidthComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.rxVga1GainTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(184, 251);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(12, 26);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(247, 21);
            this.deviceComboBox.TabIndex = 0;
            this.deviceComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sample Rate";
            // 
            // samplerateComboBox
            // 
            this.samplerateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplerateComboBox.FormattingEnabled = true;
            this.samplerateComboBox.Location = new System.Drawing.Point(12, 124);
            this.samplerateComboBox.Name = "samplerateComboBox";
            this.samplerateComboBox.Size = new System.Drawing.Size(103, 21);
            this.samplerateComboBox.TabIndex = 1;
            this.samplerateComboBox.SelectedIndexChanged += new System.EventHandler(this.samplerateComboBox_SelectedIndexChanged);
            // 
            // PlutoSDRTypeLabel
            // 
            this.PlutoSDRTypeLabel.Location = new System.Drawing.Point(75, 9);
            this.PlutoSDRTypeLabel.Name = "PlutoSDRTypeLabel";
            this.PlutoSDRTypeLabel.Size = new System.Drawing.Size(184, 13);
            this.PlutoSDRTypeLabel.TabIndex = 29;
            this.PlutoSDRTypeLabel.Text = "PlutoSDR";
            this.PlutoSDRTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Sampling Mode";
            // 
            // samplingModeComboBox
            // 
            this.samplingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplingModeComboBox.FormattingEnabled = true;
            this.samplingModeComboBox.Items.AddRange(new object[] {
            "Unknown",
            "RX/TX SMA",
            "J60/J61 connectors"});
            this.samplingModeComboBox.Location = new System.Drawing.Point(12, 74);
            this.samplingModeComboBox.Name = "samplingModeComboBox";
            this.samplingModeComboBox.Size = new System.Drawing.Size(247, 21);
            this.samplingModeComboBox.TabIndex = 2;
            // 
            // rxVga1GainTrackBar
            // 
            this.rxVga1GainTrackBar.LargeChange = 1;
            this.rxVga1GainTrackBar.Location = new System.Drawing.Point(16, 37);
            this.rxVga1GainTrackBar.Maximum = 71;
            this.rxVga1GainTrackBar.Name = "rxVga1GainTrackBar";
            this.rxVga1GainTrackBar.Size = new System.Drawing.Size(216, 45);
            this.rxVga1GainTrackBar.TabIndex = 32;
            this.rxVga1GainTrackBar.Value = 20;
            this.rxVga1GainTrackBar.Scroll += new System.EventHandler(this.rxVga1GainTrackBar_Scroll);
            // 
            // rxVga1gainLabel
            // 
            this.rxVga1gainLabel.Location = new System.Drawing.Point(164, 21);
            this.rxVga1gainLabel.Name = "rxVga1gainLabel";
            this.rxVga1gainLabel.Size = new System.Drawing.Size(68, 13);
            this.rxVga1gainLabel.TabIndex = 34;
            this.rxVga1gainLabel.Text = "5dB";
            this.rxVga1gainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Manual Gain";
            // 
            // fpgaOpenFileDialog
            // 
            this.fpgaOpenFileDialog.AddExtension = false;
            this.fpgaOpenFileDialog.FileName = "openFileDialog1";
            this.fpgaOpenFileDialog.Filter = "rbf files|*.rbf";
            this.fpgaOpenFileDialog.ReadOnlyChecked = true;
            this.fpgaOpenFileDialog.Title = "Choose FPGA file";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(8, 517);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(168, 23);
            this.labelVersion.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Bandwidth";
            // 
            // bandwidthComboBox
            // 
            this.bandwidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bandwidthComboBox.FormattingEnabled = true;
            this.bandwidthComboBox.Location = new System.Drawing.Point(134, 124);
            this.bandwidthComboBox.Name = "bandwidthComboBox";
            this.bandwidthComboBox.Size = new System.Drawing.Size(125, 21);
            this.bandwidthComboBox.TabIndex = 45;
            this.bandwidthComboBox.SelectedIndexChanged += new System.EventHandler(this.bandwidthComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.rxVga1gainLabel);
            this.groupBox2.Controls.Add(this.rxVga1GainTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 89);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gain controls";
            // 
            // PlutoSDRControllerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(272, 281);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bandwidthComboBox);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.samplingModeComboBox);
            this.Controls.Add(this.PlutoSDRTypeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.samplerateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceComboBox);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlutoSDRControllerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PlutoSDR Properties";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlutoSDRControllerDialog_FormClosing);
            this.Load += new System.EventHandler(this.PlutoSDRControllerDialog_Load);
            this.VisibleChanged += new System.EventHandler(this.PlutoSDRControllerDialog_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.rxVga1GainTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox samplerateComboBox;
        private System.Windows.Forms.Label PlutoSDRTypeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox samplingModeComboBox;
        private System.Windows.Forms.TrackBar rxVga1GainTrackBar;
        private System.Windows.Forms.Label rxVga1gainLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog fpgaOpenFileDialog;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox bandwidthComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

