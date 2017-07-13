using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Models
{
    public class MeetingRoom
    {
        public string Id { get; set; }
        public string RoomName { get; set; }
        public string RoomLocation { get; set; }
        public string RoomFloor { get; set; }
        public int Capacity { get; set; }
        public bool DayAvailableMon { get; set; }
        public bool DayAvailableTue { get; set; }
        public bool DayAvailableWed { get; set; }
        public bool DayAvailableThu { get; set; }
        public bool DayAvailableFri { get; set; }
        public bool DayAvailableSat { get; set; }
        public bool DayAvailableSun { get; set; }
        public int TimeAvailableStart { get; set; }
        public int TimeAvailableEnd { get; set; }
    }
}