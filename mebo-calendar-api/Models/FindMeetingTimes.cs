using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Models
{
    public class FindMeetingTimeRequest
    {
        public List<Attendee> attendees { get; set; }
        public TimeConstraint timeConstraint { get; set; }
        public string meetingDuration { get; set; }
        public string returnSuggestionReasons { get; set; }
    }

    public class FindMeetingTimeResponse
    {
        public string emptySuggestionsReason { get; set; }
        public List<MeetingTimeSuggestion> meetingTimeSuggestions { get; set; }
    }

    public class EmailAddress
    {
        public string name { get; set; }
        public string address { get; set; }
    }

    public class Attendee
    {
        public string type { get; set; }
        public EmailAddress emailAddress { get; set; }
    }

    public class Location
    {
        public string resolveAvailability { get; set; }
        public string displayName { get; set; }
    }

    public class Timeslot
    {
        public Time start { get; set; }
        public Time end { get; set; }
    }

    public class TimeConstraint
    {
        public string activityDomain { get; set; }
        public List<Timeslot> timeslots { get; set; }
    }

    public class MeetingTimeSuggestion
    {
        public double confidence { get; set; }
        public string organizerAvailability { get; set; }
        public string suggestionReason { get; set; }
        public MeetingTimeSlot meetingTimeSlot { get; set; }
        public List<AttendeeAvailability> attendeeAvailability { get; set; }
        public List<Location> locations { get; set; }
    }

    public class Time
    {
        public string dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class MeetingTimeSlot
    {
        public Time start { get; set; }
        public Time end { get; set; }
    }

    public class AttendeeAvailability
    {
        public string availability { get; set; }
        public Attendee attendee { get; set; }
    }
}