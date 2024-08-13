using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class CusFormSettings
    {
        private static Dictionary<string, string> settings = new Dictionary<string, string>();

        public static void SetSettingValue(string key, string value)
        {
            settings[key] = value;
        }

        public static string GetSettingValue(string key)
        {
            return settings.ContainsKey(key) ? settings[key] : null;
        }
    }
}
