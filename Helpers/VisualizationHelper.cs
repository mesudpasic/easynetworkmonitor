using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetworkMonitor.Helpers
{
    public class VisualizationHelper
    {
        public static IList<GridItem> GridSource = new SortableBindingList<GridItem>();
        private static List<TcpRecord> mapItems = new List<TcpRecord>();

        public static IList<GMapMarker> Markers = new List<GMapMarker>();
        public static void UpdateMarkers(GMapOverlay overlay)
        {
            overlay.Markers.Clear();
            mapItems.GroupBy(fn=>new { fn.GeoData.Lat, fn.GeoData.Lon, fn.GeoData.CountryCode,fn.City}).ToList().ForEach(item =>
            {
                
                GMapMarker marker = new GMarkerGoogle(new GMap.NET.PointLatLng(item.Key.Lat,item.Key.Lon), GMarkerGoogleType.red);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                //find all pocesses connecting to same lat, lon
                var pName = mapItems.Where(fn => fn.GeoData.Lat == item.Key.Lat && fn.GeoData.Lon == item.Key.Lon).Select(s => $"{s.ProcessName} ({s.RemoteAddress.ToString()}:{s.RemotePort.ToString()})").Distinct().Aggregate((i, j) => $"{i}\n{j}");
                String toolTip = $"{item.Key.City},{item.Key.CountryCode}\n{pName}";
                marker.ToolTipText = toolTip;
                overlay.Markers.Add(marker);
            });
            
        }
        public static Boolean CheckData(ref Settings settings)
        {
            List<GridItem> results = new List<GridItem>();
            List<TcpRecord> tcpList = NetworkHelper.GetTcpConnections(settings.ExcludeAppFromTCPConnections);
            List<UdpRecord> udpList = NetworkHelper.GetUdpConnections();
            Boolean wasChange = false;
            if (GridSource.Count > 0)
            {
                results = GridSource.ToList();
                //remove non existing ones from old list
                var nonExisting = results.Where(fn => fn.Protocol == "TCP").ToList().Where(fn => !tcpList.Select(t => t.ID).ToList().Contains(fn.ID)).ToList();
                nonExisting.ForEach(it =>
                {
                    results.Remove(it);
                    mapItems.Remove(mapItems.Where(fn=>fn.ID==it.ID).FirstOrDefault());
                });

                nonExisting = results.Where(fn => fn.Protocol == "UDP").ToList().Where(fn => !udpList.Select(t => t.ID).ToList().Contains(fn.ID)).ToList();
                nonExisting.ForEach(it =>
                {
                    results.Remove(it);
                });
            }
            else
            {
                wasChange = true;
            }
            tcpList.ForEach(t =>
            {
                if (results.Where(fn => fn.Protocol == t.Protocol && fn.ID == t.ID).Count() == 0)
                {
                    t.UpdateDetails();
                    if (t.GeoData.IsOK())
                        mapItems.Add(t);
                    results.Add(new GridItem(t.ID, t.Protocol, t.LocalPort, t.LocalAddress.ToString(), t.RemoteAddress.ToString(), t.RemotePort, t.Country, t.City, t.StateText, t.ProcessName, t.PID, t.ProcessIcon, t.ProcessPath));
                    wasChange = true;
                }
            });
            udpList.ForEach(t =>
            {
                if (results.Where(fn => fn.Protocol == t.Protocol && fn.ID == t.ID).Count() == 0)
                {
                    results.Add(new GridItem(t.ID, t.Protocol, (int)t.LocalPort, t.LocalAddress.ToString(), String.Empty, -1, String.Empty, String.Empty, String.Empty, t.ProcessName, t.PID, t.ProcessIcon, t.ProcessPath));
                    wasChange = true;
                }
            });
            if (wasChange)
            {                
                GridSource = new SortableBindingList<GridItem>(results);
            }
            return wasChange;
        }
    }
}
