using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace File__Directory__FileStream__Serialize
{
    internal class Helper
    {
        public static void SaveToJson(object? obj,string path)
        {
            if (obj is null) return;
            string json = JsonConvert.SerializeObject(obj);
            if (!File.Exists(path)) File.Create(path);
            WriteToJson(json, path);
        }
        private static void WriteToJson(string str,string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(str);
            }
        }
        public static T? JsonToObject<T>(string str) where T : class
        {
            if (String.IsNullOrEmpty(str)) return null;
            T newT = JsonConvert.DeserializeObject<T>(str);
            return newT;
        }
    }
}
