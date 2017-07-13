using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string s)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<T>(s);
        }
    }
}