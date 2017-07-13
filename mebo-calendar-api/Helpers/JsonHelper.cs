using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace mebo_calendar_api.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string s)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(s);
        }

        public static string Serialize<T>(T obj)
        {
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, obj);
            var sr = new StreamReader(stream1);
            var s = sr.ReadToEnd();
            return s;
        }
    }
}