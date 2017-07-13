using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Models
{
    public class BookMeetingRequest
    {
        public string[] names { get; set; }
        public int duration { get; set; }
    }
}