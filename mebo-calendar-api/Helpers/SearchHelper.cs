using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Helpers
{
    public class SearchHelper
    {
        public static bool IsStringInArray(string s, string[] elements)
        {
            foreach (var e in elements)
            {
                if (s.IndexOf(e, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}