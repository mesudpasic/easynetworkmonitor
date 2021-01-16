
namespace EasyTrafficMonitor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.sbMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuApp = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.gvGrid = new System.Windows.Forms.DataGridView();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoteAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemotePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrRefreshList = new System.Windows.Forms.Timer(this.components);
            this.tabPacketSniffer = new System.Windows.Forms.TabPage();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.btnSniffer = new System.Windows.Forms.Button();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowApp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExitSysTray = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.gvRecords = new System.Windows.Forms.DataGridView();
            this.sbMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.sysTrayMenu.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            this.tabPacketSniffer.SuspendLayout();
            this.pnlDevice.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // sbMain
            // 
            this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblVersion});
            this.sbMain.Location = new System.Drawing.Point(0, 624);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(1222, 22);
            this.sbMain.TabIndex = 0;
            this.sbMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 17);
            this.lblVersion.Text = "Version:";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuApp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1222, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuApp
            // 
            this.mnuApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuExit});
            this.mnuApp.Name = "mnuApp";
            this.mnuApp.Size = new System.Drawing.Size(80, 20);
            this.mnuApp.Text = "&Application";
            // 
            // sysTray
            // 
            this.sysTray.ContextMenuStrip = this.sysTrayMenu;
            this.sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTray.Icon")));
            this.sysTray.Text = "Show Main Window";
            this.sysTray.Visible = true;
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowApp,
            this.mnuExitSysTray});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(168, 48);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabMap);
            this.tcMain.Controls.Add(this.tabGrid);
            this.tcMain.Controls.Add(this.tabPacketSniffer);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1222, 600);
            this.tcMain.TabIndex = 2;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.mapControl);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(1214, 574);
            this.tabMap.TabIndex = 0;
            this.tabMap.Text = "Map View";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // mapControl
            // 
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(3, 3);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 2;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomEnabled = true;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.mapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(1208, 568);
            this.mapControl.TabIndex = 0;
            this.mapControl.Zoom = 0D;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.gvGrid);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(1214, 574);
            this.tabGrid.TabIndex = 1;
            this.tabGrid.Text = "List View";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // gvGrid
            // 
            this.gvGrid.AllowUserToAddRows = false;
            this.gvGrid.AllowUserToDeleteRows = false;
            this.gvGrid.AllowUserToResizeRows = false;
            this.gvGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Protocol,
            this.LocalPort,
            this.LocalAddress,
            this.RemoteAddress,
            this.RemotePort,
            this.Country,
            this.City,
            this.Status,
            this.ProcessName,
            this.PID});
            this.gvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGrid.Location = new System.Drawing.Point(3, 3);
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.ReadOnly = true;
            this.gvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvGrid.ShowEditingIcon = false;
            this.gvGrid.Size = new System.Drawing.Size(1208, 568);
            this.gvGrid.TabIndex = 3;
            // 
            // Protocol
            // 
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Name = "Protocol";
            this.Protocol.ReadOnly = true;
            this.Protocol.Width = 117;
            // 
            // LocalPort
            // 
            this.LocalPort.HeaderText = "Local Port";
            this.LocalPort.Name = "LocalPort";
            this.LocalPort.ReadOnly = true;
            this.LocalPort.Width = 116;
            // 
            // LocalAddress
            // 
            this.LocalAddress.HeaderText = "Local Address";
            this.LocalAddress.Name = "LocalAddress";
            this.LocalAddress.ReadOnly = true;
            this.LocalAddress.Width = 117;
            // 
            // RemoteAddress
            // 
            this.RemoteAddress.HeaderText = "Remote Address";
            this.RemoteAddress.Name = "RemoteAddress";
            this.RemoteAddress.ReadOnly = true;
            this.RemoteAddress.Width = 116;
            // 
            // RemotePort
            // 
            this.RemotePort.HeaderText = "Remote Port";
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.ReadOnly = true;
            this.RemotePort.Width = 117;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 116;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 117;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 116;
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            this.ProcessName.Width = 117;
            // 
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Width = 116;
            // 
            // tmrRefreshList
            // 
            this.tmrRefreshList.Interval = 5000;
            this.tmrRefreshList.Tick += new System.EventHandler(this.tmrRefreshList_Tick);
            // 
            // tabPacketSniffer
            // 
            this.tabPacketSniffer.Controls.Add(this.pnlContainer);
            this.tabPacketSniffer.Controls.Add(this.pnlDevice);
            this.tabPacketSniffer.Location = new System.Drawing.Point(4, 22);
            this.tabPacketSniffer.Name = "tabPacketSniffer";
            this.tabPacketSniffer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPacketSniffer.Size = new System.Drawing.Size(1214, 574);
            this.tabPacketSniffer.TabIndex = 2;
            this.tabPacketSniffer.Text = "Packet Sniffer";
            this.tabPacketSniffer.UseVisualStyleBackColor = true;
            // 
            // pnlDevice
            // 
            this.pnlDevice.Controls.Add(this.btnSniffer);
            this.pnlDevice.Controls.Add(this.cbDevice);
            this.pnlDevice.Controls.Add(this.lblDevice);
            this.pnlDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDevice.Location = new System.Drawing.Point(3, 3);
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(1208, 48);
            this.pnlDevice.TabIndex = 0;
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(6, 11);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(72, 13);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "Select device";
            // 
            // cbDevice
            // 
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(80, 7);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(473, 21);
            this.cbDevice.TabIndex = 1;
            // 
            // btnSniffer
            // 
            this.btnSniffer.Image = global::EasyNetworkMonitor.Properties.Resources.start;
            this.btnSniffer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSniffer.Location = new System.Drawing.Point(560, 5);
            this.btnSniffer.Name = "btnSniffer";
            this.btnSniffer.Size = new System.Drawing.Size(73, 37);
            this.btnSniffer.TabIndex = 2;
            this.btnSniffer.Tag = "0";
            this.btnSniffer.Text = "Start";
            this.btnSniffer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSniffer.UseVisualStyleBackColor = true;
            this.btnSniffer.Click += new System.EventHandler(this.btnSniffer_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::EasyNetworkMonitor.Properties.Resources.settings;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(116, 22);
            this.mnuSettings.Text = "&Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::EasyNetworkMonitor.Properties.Resources.exit;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(116, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuShowApp
            // 
            this.mnuShowApp.Image = global::EasyNetworkMonitor.Properties.Resources.show;
            this.mnuShowApp.Name = "mnuShowApp";
            this.mnuShowApp.Size = new System.Drawing.Size(167, 22);
            this.mnuShowApp.Text = "Show Application";
            this.mnuShowApp.Click += new System.EventHandler(this.mnuShowApp_Click);
            // 
            // mnuExitSysTray
            // 
            this.mnuExitSysTray.Image = global::EasyNetworkMonitor.Properties.Resources.exit;
            this.mnuExitSysTray.Name = "mnuExitSysTray";
            this.mnuExitSysTray.Size = new System.Drawing.Size(167, 22);
            this.mnuExitSysTray.Text = "Exit";
            this.mnuExitSysTray.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.gvRecords);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(3, 51);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1208, 520);
            this.pnlContainer.TabIndex = 1;
            // 
            // gvRecords
            // 
            this.gvRecords.AllowUserToAddRows = false;
            this.gvRecords.AllowUserToDeleteRows = false;
            this.gvRecords.AllowUserToResizeRows = false;
            this.gvRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRecords.Location = new System.Drawing.Point(0, 0);
            this.gvRecords.Name = "gvRecords";
            this.gvRecords.ReadOnly = true;
            this.gvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvRecords.ShowEditingIcon = false;
            this.gvRecords.Size = new System.Drawing.Size(1208, 520);
            this.gvRecords.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 646);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy Network Monitor & Packet Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.sbMain.ResumeLayout(false);
            this.sbMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.sysTrayMenu.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            this.tabPacketSniffer.ResumeLayout(false);
            this.pnlDevice.ResumeLayout(false);
            this.pnlDevice.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sbMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuApp;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.NotifyIcon sysTray;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuShowApp;
        private System.Windows.Forms.ToolStripMenuItem mnuExitSysTray;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.Timer tmrRefreshList;
        private System.Windows.Forms.DataGridView gvGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemoteAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemotePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private GMap.NET.WindowsForms.GMapControl mapControl;
        private System.Windows.Forms.TabPage tabPacketSniffer;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Button btnSniffer;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.DataGridView gvRecords;
    }
}

