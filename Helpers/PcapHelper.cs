using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using System.Collections.ObjectModel;
using System.Net;
using SharpPcap;
using PacketDotNet.Utils;
using PacketDotNet;

namespace EasyNetworkMonitor.Helpers
{
	public class PcapHelper
    {
        private static ICaptureDevice currentDevice; //curent device we capture
        public static Form CurrentAppForm; //app form to call Invoke for UI changes, needs updates
        private static object QueueLock = new object(); //used to lock between threads in order to update PacketQueue
        private static List<RawCapture> PacketQueue = new List<RawCapture>(); //I put here all packets captured
        private static bool BackgroundThreadStop; //flag
        private static System.Threading.Thread BackgroundThread;//thread to parse packets

        private static PacketArrivalEventHandler arrivalEventHandler;

        public static IList<PacketDataItem> PacketDataSource = new SortableBindingList<PacketDataItem>();
        public static void FillDeviceDropDownList(ComboBox combo)
        {
            try
            {
                //this API call has nicer name that CaptureDeviceList.Instance, so I'll use this one :)
                combo.Items.Clear();
                PacketQueue.Clear();
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    String name = String.Format("{0} {1}", adapter.Name, adapter.Description);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = name;
                    item.Value = adapter.Id;
                    combo.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error fiiling out the devices list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void StartSniffing(ComboboxItem deviceItem)
        {
            PacketDataSource.Clear();
            var devices = CaptureDeviceList.Instance;
            currentDevice = devices.Where(fn => fn.Name.Contains(deviceItem.Value.ToString())).FirstOrDefault(); //find device by name ID
            if (currentDevice != null)
            {
                try
                {
                    //this needs more work, app is still slow and blocking
                    arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);
                    currentDevice.OnPacketArrival += arrivalEventHandler;
                    BackgroundThreadStop = false;
                    BackgroundThread = new System.Threading.Thread(RunBackgroundThread);
                    BackgroundThread.Start();

                    currentDevice.Open(DeviceMode.Promiscuous, 1000);

                    //string filter = "ip and tcp";
                    //device.Filter = filter;

                    // Start capture 'INFINTE' number of packets
                    currentDevice.Capture();
                } catch
                {

                }

            }
        }
        public static void StopSniffing()
        {
            try
            {
                currentDevice.StopCapture();
                currentDevice.Close();
                currentDevice.OnPacketArrival -= arrivalEventHandler;
                currentDevice = null;
                BackgroundThreadStop = true;
                // wait for the background thread to terminate
                BackgroundThread.Join();
            }
            catch
            {

            }
        }
        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            
            lock (QueueLock)
            {
                PacketQueue.Add(e.Packet);
            }
        }
        private static void RunBackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    System.Threading.Thread.Sleep(250);
                }
                else // should process the queue
                {
                    List<RawCapture> ourQueue;
                    lock (QueueLock)
                    {
                        // swap queues, giving the capture callback a new one
                        ourQueue = PacketQueue;
                        PacketQueue = new List<RawCapture>();
                    }

                    

                    foreach (var p in ourQueue)
                    {
                        var packet = PacketDotNet.Packet.ParsePacket(p.LinkLayerType, p.Data);
                        var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
                        if (tcpPacket != null)
                        {
                            var ipPacket = (PacketDotNet.IPPacket)tcpPacket.ParentPacket;

                            PacketDataItem item = new PacketDataItem();
                            item.Protocol = "TCP";
                            item.LocalAddress = ipPacket.SourceAddress.ToString();
                            item.LocalPort = tcpPacket.SourcePort;
                            item.RemoteAddress = ipPacket.DestinationAddress.ToString();
                            item.RemotePort = tcpPacket.DestinationPort;
                            item.PacketLength = p.Data.Length;
                            item.TimeStamp = p.Timeval.Date;
                            //this needs fix
                            CurrentAppForm.BeginInvoke(new Action(() =>
                            {
                                PacketDataSource.Add(item);                                
                            }));          
                        }
                        else
                        {
                            var udpPacket = packet.Extract<PacketDotNet.UdpPacket>();
                            if (udpPacket != null)
                            {
                                var ipPacket = (PacketDotNet.IPPacket)udpPacket.ParentPacket;

                                PacketDataItem item = new PacketDataItem();
                                item.Protocol = "UDP";
                                item.LocalAddress = ipPacket.SourceAddress.ToString();
                                item.LocalPort = udpPacket.SourcePort;
                                item.RemoteAddress = ipPacket.DestinationAddress.ToString();
                                item.RemotePort = udpPacket.DestinationPort;
                                item.PacketLength = p.Data.Length;
                                item.TimeStamp = p.Timeval.Date;
                                //this needs fix
                                CurrentAppForm.BeginInvoke(new Action(() =>
                                {
                                    PacketDataSource.Add(item);                                    
                                }));

                            }
                        }
                    }
                }
            }
        }

    }
    public class PacketDataItem
    {
        public DateTime TimeStamp { get; set; }
        public String Protocol { get; set; }
        public String LocalAddress { get; set; }
        public Int32 LocalPort { get; set; }
        public String RemoteAddress { get; set; }     
        public Int32 RemotePort { get; set; }

        public Int32 PacketLength { get; set; }
    }
    public class ComboboxItem
	{
		public string Text { get; set; }
		public object Value { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}
