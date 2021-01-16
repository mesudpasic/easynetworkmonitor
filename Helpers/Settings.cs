using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Windows.Forms;

namespace EasyNetworkMonitor.Helpers
{
    public class SettingsHelper
    {
        public static Settings GetSettings()
        {
            Settings r = new Settings();
            r.ExcludeAppFromTCPConnections = true;
            try
            {
                String path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "settings.json");
                if (File.Exists(path))
                {
                    r = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                }
            } catch (Exception e)
            {
                //add logs
            }
            return r;
        }
        public static void SaveSettings(Settings s)
        {
            try
            {
                String path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "settings.json");
                File.WriteAllText(path, JsonConvert.SerializeObject(s));
            }
            catch (Exception e)
            {
                //add logs
            }
        }
    }

    [Serializable]
    public class Settings
    {
        [JsonProperty("ExcludeAppFromTCPConnections")]
        public Boolean ExcludeAppFromTCPConnections { get; set; }
        [JsonProperty("LastDeviceUsed")]
        public String LastDeviceUsed { get; set; }

    }
}
