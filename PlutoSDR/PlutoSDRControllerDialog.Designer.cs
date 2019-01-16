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
            System.Windows.Forms.TabPage receiverTabPage;
            this.receiverPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.agcEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rxVga1gainLabel = new System.Windows.Forms.Label();
            this.rxVga1GainTrackBar = new System.Windows.Forms.TrackBar();
            this.samplerateComboBox = new System.Windows.Forms.ComboBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.deviceUriTextbox = new System.Windows.Forms.TextBox();
            this.versionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.connectButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.connectionTabPage = new System.Windows.Forms.TabPage();
            this.contextDetailsLabel = new System.Windows.Forms.Label();
            this.libiioVersionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.advancedTabPage = new System.Windows.Forms.TabPage();
            this.rssiLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bandwidthLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bufferReadSizeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            receiverTabPage = new System.Windows.Forms.TabPage();
            receiverTabPage.SuspendLayout();
            this.receiverPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rxVga1GainTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.connectionTabPage.SuspendLayout();
            this.advancedTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // receiverTabPage
            // 
            receiverTabPage.Controls.Add(this.receiverPanel);
            receiverTabPage.Location = new System.Drawing.Point(4, 26);
            receiverTabPage.Name = "receiverTabPage";
            receiverTabPage.Padding = new System.Windows.Forms.Padding(3);
            receiverTabPage.Size = new System.Drawing.Size(291, 233);
            receiverTabPage.TabIndex = 1;
            receiverTabPage.Text = "Receiver";
            receiverTabPage.UseVisualStyleBackColor = true;
            // 
            // receiverPanel
            // 
            this.receiverPanel.Controls.Add(this.label3);
            this.receiverPanel.Controls.Add(this.groupBox2);
            this.receiverPanel.Controls.Add(this.samplerateComboBox);
            this.receiverPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiverPanel.Enabled = false;
            this.receiverPanel.Location = new System.Drawing.Point(3, 3);
            this.receiverPanel.Name = "receiverPanel";
            this.receiverPanel.Size = new System.Drawing.Size(285, 227);
            this.receiverPanel.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sample Rate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.agcEnabledCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.rxVga1gainLabel);
            this.groupBox2.Controls.Add(this.rxVga1GainTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(15, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 136);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gain controls";
            // 
            // agcEnabledCheckBox
            // 
            this.agcEnabledCheckBox.AutoSize = true;
            this.agcEnabledCheckBox.Location = new System.Drawing.Point(16, 92);
            this.agcEnabledCheckBox.Name = "agcEnabledCheckBox";
            this.agcEnabledCheckBox.Size = new System.Drawing.Size(121, 21);
            this.agcEnabledCheckBox.TabIndex = 35;
            this.agcEnabledCheckBox.Text = "slow_attack AGC";
            this.agcEnabledCheckBox.UseVisualStyleBackColor = true;
            this.agcEnabledCheckBox.CheckedChanged += new System.EventHandler(this.agcEnabledCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Manual Gain";
            // 
            // rxVga1gainLabel
            // 
            this.rxVga1gainLabel.Location = new System.Drawing.Point(164, 21);
            this.rxVga1gainLabel.Name = "rxVga1gainLabel";
            this.rxVga1gainLabel.Size = new System.Drawing.Size(68, 17);
            this.rxVga1gainLabel.TabIndex = 34;
            this.rxVga1gainLabel.Text = "5dB";
            this.rxVga1gainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rxVga1GainTrackBar
            // 
            this.rxVga1GainTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rxVga1GainTrackBar.LargeChange = 1;
            this.rxVga1GainTrackBar.Location = new System.Drawing.Point(16, 43);
            this.rxVga1GainTrackBar.Maximum = 71;
            this.rxVga1GainTrackBar.Name = "rxVga1GainTrackBar";
            this.rxVga1GainTrackBar.Size = new System.Drawing.Size(216, 45);
            this.rxVga1GainTrackBar.TabIndex = 32;
            this.rxVga1GainTrackBar.Value = 20;
            this.rxVga1GainTrackBar.Scroll += new System.EventHandler(this.rxVga1GainTrackBar_Scroll);
            // 
            // samplerateComboBox
            // 
            this.samplerateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplerateComboBox.FormattingEnabled = true;
            this.samplerateComboBox.Location = new System.Drawing.Point(15, 36);
            this.samplerateComboBox.Name = "samplerateComboBox";
            this.samplerateComboBox.Size = new System.Drawing.Size(244, 25);
            this.samplerateComboBox.TabIndex = 1;
            this.samplerateComboBox.SelectedIndexChanged += new System.EventHandler(this.samplerateComboBox_SelectedIndexChanged);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(234, 281);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 26);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Device-URI";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(8, 517);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(168, 23);
            this.labelVersion.TabIndex = 41;
            // 
            // deviceUriTextbox
            // 
            this.deviceUriTextbox.Location = new System.Drawing.Point(14, 42);
            this.deviceUriTextbox.Name = "deviceUriTextbox";
            this.deviceUriTextbox.Size = new System.Drawing.Size(184, 25);
            this.deviceUriTextbox.TabIndex = 48;
            this.deviceUriTextbox.Text = "ip:10.4.15.1";
            // 
            // versionLinkLabel
            // 
            this.versionLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLinkLabel.AutoSize = true;
            this.versionLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLinkLabel.Location = new System.Drawing.Point(13, 286);
            this.versionLinkLabel.Name = "versionLinkLabel";
            this.versionLinkLabel.Size = new System.Drawing.Size(82, 17);
            this.versionLinkLabel.TabIndex = 49;
            this.versionLinkLabel.TabStop = true;
            this.versionLinkLabel.Text = "Version 0.5.0";
            this.versionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.versionLinkLabel_LinkClicked);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(204, 42);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(73, 25);
            this.connectButton.TabIndex = 50;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.connectionTabPage);
            this.tabControl1.Controls.Add(receiverTabPage);
            this.tabControl1.Controls.Add(this.advancedTabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(299, 263);
            this.tabControl1.TabIndex = 52;
            // 
            // connectionTabPage
            // 
            this.connectionTabPage.Controls.Add(this.contextDetailsLabel);
            this.connectionTabPage.Controls.Add(this.libiioVersionLabel);
            this.connectionTabPage.Controls.Add(this.label2);
            this.connectionTabPage.Controls.Add(this.label1);
            this.connectionTabPage.Controls.Add(this.connectButton);
            this.connectionTabPage.Controls.Add(this.deviceUriTextbox);
            this.connectionTabPage.Location = new System.Drawing.Point(4, 26);
            this.connectionTabPage.Name = "connectionTabPage";
            this.connectionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectionTabPage.Size = new System.Drawing.Size(291, 233);
            this.connectionTabPage.TabIndex = 0;
            this.connectionTabPage.Text = "Connection";
            this.connectionTabPage.UseVisualStyleBackColor = true;
            // 
            // contextDetailsLabel
            // 
            this.contextDetailsLabel.Location = new System.Drawing.Point(13, 98);
            this.contextDetailsLabel.Name = "contextDetailsLabel";
            this.contextDetailsLabel.Size = new System.Drawing.Size(264, 62);
            this.contextDetailsLabel.TabIndex = 54;
            // 
            // libiioVersionLabel
            // 
            this.libiioVersionLabel.AutoSize = true;
            this.libiioVersionLabel.Location = new System.Drawing.Point(100, 81);
            this.libiioVersionLabel.Name = "libiioVersionLabel";
            this.libiioVersionLabel.Size = new System.Drawing.Size(0, 17);
            this.libiioVersionLabel.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "libiio-Version:";
            // 
            // advancedTabPage
            // 
            this.advancedTabPage.Controls.Add(this.rssiLabel);
            this.advancedTabPage.Controls.Add(this.label8);
            this.advancedTabPage.Controls.Add(this.bandwidthLabel);
            this.advancedTabPage.Controls.Add(this.label7);
            this.advancedTabPage.Controls.Add(this.bufferReadSizeLabel);
            this.advancedTabPage.Controls.Add(this.label4);
            this.advancedTabPage.Location = new System.Drawing.Point(4, 26);
            this.advancedTabPage.Name = "advancedTabPage";
            this.advancedTabPage.Size = new System.Drawing.Size(291, 233);
            this.advancedTabPage.TabIndex = 2;
            this.advancedTabPage.Text = "Advanced";
            this.advancedTabPage.UseVisualStyleBackColor = true;
            // 
            // rssiLabel
            // 
            this.rssiLabel.AutoSize = true;
            this.rssiLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rssiLabel.Location = new System.Drawing.Point(110, 66);
            this.rssiLabel.Name = "rssiLabel";
            this.rssiLabel.Size = new System.Drawing.Size(0, 17);
            this.rssiLabel.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "RSSI:";
            // 
            // bandwidthLabel
            // 
            this.bandwidthLabel.AutoSize = true;
            this.bandwidthLabel.Location = new System.Drawing.Point(109, 40);
            this.bandwidthLabel.Name = "bandwidthLabel";
            this.bandwidthLabel.Size = new System.Drawing.Size(0, 17);
            this.bandwidthLabel.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bandwidth:";
            // 
            // bufferReadSizeLabel
            // 
            this.bufferReadSizeLabel.AutoSize = true;
            this.bufferReadSizeLabel.Location = new System.Drawing.Point(109, 13);
            this.bufferReadSizeLabel.Name = "bufferReadSizeLabel";
            this.bufferReadSizeLabel.Size = new System.Drawing.Size(0, 17);
            this.bufferReadSizeLabel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buffer size:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkLabel4);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.linkLabel3);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.linkLabel2);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(291, 233);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "About";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(11, 141);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(170, 17);
            this.linkLabel4.TabIndex = 8;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "E-Mail / t.maedel@alfeld.de";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "Issues? Suggestions?";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(11, 121);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(235, 17);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "GitHub / manawyrm/sdrsharp-plutosdr";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(285, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Uses libiio and libad9361-iio by Analog Devices";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Licensed under:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(11, 207);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(196, 17);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "GNU General Public License v3.0";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(68, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(205, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Tobias Mädel (https://tbspace.de)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "written by ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "PlutoSDR for SDR#";
            // 
            // PlutoSDRControllerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(323, 319);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.versionLinkLabel);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.closeButton);
            this.DoubleBuffered = true;
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
            this.VisibleChanged += new System.EventHandler(this.PlutoSDRControllerDialog_VisibleChanged);
            receiverTabPage.ResumeLayout(false);
            this.receiverPanel.ResumeLayout(false);
            this.receiverPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rxVga1GainTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.connectionTabPage.ResumeLayout(false);
            this.connectionTabPage.PerformLayout();
            this.advancedTabPage.ResumeLayout(false);
            this.advancedTabPage.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer refreshTimer;
        public System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox samplerateComboBox;
        public System.Windows.Forms.TrackBar rxVga1GainTrackBar;
        public System.Windows.Forms.Label rxVga1gainLabel;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label labelVersion;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox agcEnabledCheckBox;
        public System.Windows.Forms.TextBox deviceUriTextbox;
        public System.Windows.Forms.LinkLabel versionLinkLabel;
        public System.Windows.Forms.Button connectButton;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage connectionTabPage;
        public System.Windows.Forms.TabPage advancedTabPage;
        public System.Windows.Forms.Panel receiverPanel;
        public System.Windows.Forms.Label libiioVersionLabel;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label bufferReadSizeLabel;
        public System.Windows.Forms.Label bandwidthLabel;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label rssiLabel;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label contextDetailsLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label11;
    }
}

