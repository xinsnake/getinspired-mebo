//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mebo_meetingroom_api.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeetingRoom
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