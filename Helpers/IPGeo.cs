using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Net.Http;
using System.IO;


namespace EasyNetworkMonitor.Helpers
{
    public class IPGeo
    {
        private static String IP2GeoUrl="http://ip-api.com/json/";

        //used to filter it out from requests
        public static IPAddress GetIPFromIP2GeoSite()
        {
            try
            {
                Uri uri = new Uri(IP2GeoUrl);
                return Dns.GetHostAddresses(uri.Host)[0];
            } catch (Exception e)
            {
                //add logs
                return null;
            }
        }
        public static Geo GetGeoInfo(String ip)
        {
            Geo r = new Geo();
            try
            {
                WebRequest request = WebRequest.Create($"{IP2GeoUrl}{ip}");
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string res = reader.ReadToEnd();
                r = JsonConvert.DeserializeObject<Geo>(res);

            } catch (Exception e)
            {
                //add logs
            }
            return r;
        }
    }
    [Serializable]
    public partial class Geo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("region")]        
        public String Region { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]        
        public String Zip { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("isp")]
        public string Isp { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("as")]
        public string As { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        public Boolean IsOK()
        {
            return this.Status == "success";
        }
    }
}
