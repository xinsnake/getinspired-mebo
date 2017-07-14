using mebo_calendar_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Helpers
{
    public class DateHelper
    {
        public static Timeslot GetNextMeetingTimeslot()
        {
            var now = DateTime.Now;
            var start = RoundUp(now.AddHours(1), TimeSpan.FromMinutes(30));
            while (IsWeekEnd(start) || !IsWorkingHour(start))
            {
                start = start.AddHours(1);
            }
            var end = start.AddDays(5);
            while (IsWeekEnd(end) || !IsWorkingHour(end))
            {
                end = end.AddDays(1);
            };

            var startTime = new Time()
            {
                dateTime = start.ToString("yyyy-MM-ddThh:mm:ss"),
                timeZone = "Australia/Sydney"
            };
            var endTime = new Time()
            {
                dateTime = end.ToString("yyyy-MM-ddThh:mm:ss"),
                timeZone = "Australia/Sydney"
            };

            return new Timeslot()
            {
                start = startTime,
                end = endTime
            };
        }

        private static bool IsWeekEnd(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsWorkingHour(DateTime date)
        {
            return date.Hour >= 9 && date.Hour <= 17;
        }

        private static DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }
    }
}