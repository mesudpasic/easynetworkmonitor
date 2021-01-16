using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EasyNetworkMonitor.Helpers;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using EasyNetworkMonitor.Properties;

namespace EasyTrafficMonitor
{
    public partial class frmMain : Form
    {
        public GMapOverlay mapOverlays = new GMapOverlay("pins");
        public EasyNetworkMonitor.Helpers.Settings settings = SettingsHelper.GetSettings();
      
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = $"Version: {Application.ProductVersion}";
            tmrRefreshList.Enabled = true;
            mapControl.MapProvider = GMapProviders.YandexMap;
            mapControl.ScaleMode = ScaleModes.Fractional;            
            mapControl.MinZoom = 0;
            mapControl.MaxZoom = 24;
            mapControl.Zoom = 2;            
            mapControl.Overlays.Add(mapOverlays);
            PcapHelper.CurrentAppForm = this;
            PcapHelper.FillDeviceDropDownList(cbDevice);
            gvRecords.DataSource = PcapHelper.PacketDataSource;            
            if (VisualizationHelper.CheckData(ref settings))
            {
                gvGrid.Columns.Clear();
                gvGrid.DataSource = VisualizationHelper.GridSource;
                VisualizationHelper.UpdateMarkers(mapOverlays);
            }
            //for now until al bugs are fixed, I'll hide it, and settings menu button too
            tcMain.TabPages.Remove(tabPacketSniffer);
            mnuSettings.Visible = false;
        }
       
        private void mnuExit_Click(object sender, EventArgs e)
        {
            sysTray.Visible = false;
            Application.Exit();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {

        }

        private void mnuShowApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsHelper.SaveSettings(settings);
            Application.Exit();
        }

        private void tmrRefreshList_Tick(object sender, EventArgs e)
        {
            if (VisualizationHelper.CheckData(ref settings))
            {
                gvGrid.DataSource = VisualizationHelper.GridSource;
                VisualizationHelper.UpdateMarkers(mapOverlays);
                mapControl.Refresh();
            }   
        }

        private void btnSniffer_Click(object sender, EventArgs e)
        {
            if (cbDevice.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select device first.");
                return;
            }
            if (Convert.ToInt32(btnSniffer.Tag) == 0)
            {
                btnSniffer.Text = "Stop";
                btnSniffer.Image = Resources.stop;
                btnSniffer.Tag = 1;
                cbDevice.Enabled = false;
                tmrRefreshList.Enabled = false;
                PcapHelper.StartSniffing((cbDevice.SelectedItem as ComboboxItem));
            } else
            {
                PcapHelper.StopSniffing();
                btnSniffer.Text = "Start";
                btnSniffer.Image = Resources.start;
                btnSniffer.Tag = 0;
                cbDevice.Enabled = true;
                tmrRefreshList.Enabled = true;
            }
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
    
}
