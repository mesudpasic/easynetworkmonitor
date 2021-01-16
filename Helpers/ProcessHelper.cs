using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Diagnostics;
using System.Drawing;


namespace EasyNetworkMonitor.Helpers
{
    public class ProcessHelper
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        static extern uint GetClassLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);

        /// <summary>
        /// 64 bit version maybe loses significant 64-bit specific information
        /// </summary>
        static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return new IntPtr((long)GetClassLong32(hWnd, nIndex));
            else
                return GetClassLong64(hWnd, nIndex);
        }


        static uint WM_GETICON = 0x007f;
        static IntPtr ICON_SMALL2 = new IntPtr(2);
        static IntPtr IDI_APPLICATION = new IntPtr(0x7F00);
        static int GCL_HICON = -14;

        public ProcessHelper()
        {
        }

        public static Image GetProcessIcon(int pid)
        {
            try
            {
                if (GetProcessByID(pid) == null)
                    return null;

                IntPtr hWnd = GetProcessByID(pid).MainWindowHandle;

                IntPtr hIcon = default(IntPtr);

                hIcon = SendMessage(hWnd, WM_GETICON, ICON_SMALL2, IntPtr.Zero);

                if (hIcon == IntPtr.Zero)
                    hIcon = GetClassLongPtr(hWnd, GCL_HICON);

                if (hIcon == IntPtr.Zero)
                    hIcon = LoadIcon(IntPtr.Zero, (IntPtr)0x7F00/*IDI_APPLICATION*/);

                if (hIcon != IntPtr.Zero)                    
                    return new Bitmap(Icon.FromHandle(hIcon).ToBitmap(), 16, 16);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Process> GetListOfProcesses()
        {
            return Process.GetProcesses().ToList<Process>();
        }

        public static Process GetProcessByID(int pid)
        {
            return Process.GetProcesses().Where(p => p.Id == pid).SingleOrDefault();
        }

        public static string GetProcessNameByTcpConnection(IPAddress sourceAddress, IPAddress destinationAddress, ushort sourcePort, ushort destinationPort, IPAddress localIP)
        {
            List<TcpRecord> tcpRecords = null;
            ushort port;
            IPAddress address;

            if (localIP == sourceAddress)
            {
                port = sourcePort;
                address = sourceAddress;
            }
            else
            {
                port = destinationPort;
                address = destinationAddress;
            }
            if ((tcpRecords = NetworkHelper.GetTcpConnections()) != null && tcpRecords.Count > 0)
            {
                TcpRecord record = tcpRecords.Where(r => r.LocalPort == port).SingleOrDefault();
                if (record != null)
                {
                    return record.PID.ToString();

                    //if (record.PID == 0)
                    //    return "System";
                    //else
                    //{
                    //    Process proc = null;
                    //    if ((proc = GetProcessByID(record.PID)) != null)
                    //        return proc.ProcessName;
                    //    else
                    //        return "N/A";
                    //}
                }
            }

            return String.Empty;
        }


        public static string GetProcessNameByUDpConnection(IPAddress sourceAddress, IPAddress destinationAddress, ushort sourcePort, ushort destinationPort, IPAddress localIP)
        {
            List<UdpRecord> udpRecords = null;
            ushort port;
            IPAddress address;

            if (localIP == sourceAddress)
            {
                port = sourcePort;
                address = sourceAddress;
            }
            else
            {
                port = destinationPort;
                address = destinationAddress;
            }

            if ((udpRecords = NetworkHelper.GetUdpConnections()) != null)
            {
                UdpRecord record = udpRecords.Where(r => r.LocalPort == port).SingleOrDefault();
                if (record != null)
                    return record.PID.ToString();
            }

            return String.Empty;
        }
    }
    internal static class Extensions
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);

        public static string GetMainModuleFileName(this Process process, int buffer = 1024)
        {
            try
            {
                var fileNameBuilder = new StringBuilder(buffer);
                uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
                return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) ?
                    fileNameBuilder.ToString() :
                    null;
            }catch
            {
                return "Not Available";
            }
        }
    }
}
