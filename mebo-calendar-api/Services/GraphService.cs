using mebo_calendar_api.Helpers;
using mebo_calendar_api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Text;
using System.Xml;

namespace mebo_calendar_api.Services
{
    public class GraphService
    {
        public static async Task<IEnumerable<MeetingRoom>> GetMeetingRooms()
        {
            string endpoint = "https://mebo-meetingroom-api.azurewebsites.net/api/MeetingRooms";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var meetingRooms = JsonHelper.Deserialize<List<MeetingRoom>>(await response.Content.ReadAsStringAsync());
                            return meetingRooms;
                        }

                        throw new Exception("Error: " + response.ToString());
                    }
                }
            }
        }

        public static async Task<List<MeetingTimeSuggestion>> FindMeetingTimeAsync(string accessToken, MeetingRoom m, IEnumerable<Staff> staff, int duration)
        {
            string endpoint = $"https://graph.microsoft.com/v1.0/users/{m.Id}/findMeetingTimes";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var findMeetingTimeRequest = GetFindMeetingTimeRequest(m, staff, duration);
                    var json = JsonHelper.Serialize(findMeetingTimeRequest);
                    byte[] buf = Encoding.UTF8.GetBytes(json);
                    request.Content = new ByteArrayContent(buf);

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var findMeetingTimeResponse = JsonHelper.Deserialize<FindMeetingTimeResponse>(await response.Content.ReadAsStringAsync());
                            return findMeetingTimeResponse.meetingTimeSuggestions;
                        }

                        throw new Exception("Error: " + response.ToString());
                    }
                }
            }
        }

        public static async Task<IEnumerable<Staff>> GetStaff(string accessToken)
        {
            string endpoint = "https://graph.microsoft.com/v1.0/groups/ea7de869-36a0-4946-b9f2-a874df97d451/members";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var userResponse = JsonHelper.Deserialize<StaffResponse>(await response.Content.ReadAsStringAsync());
                            return userResponse.value;
                        }

                        throw new Exception("Error: " + response.ToString());
                    }
                }
            }
        }

        private static FindMeetingTimeRequest GetFindMeetingTimeRequest(MeetingRoom m, IEnumerable<Staff> staff, int duration)
        {
            var req = new FindMeetingTimeRequest();
            req.returnSuggestionReasons = "true";

            // attendees
            var attendees = new List<Attendee>();
            attendees.Add(new Attendee()
            {
                type = "required",
                emailAddress = new EmailAddress()
                {
                    address = m.RoomName + "@xinsnake.onmicrosoft.com"
                }
            });
            foreach (var s in staff)
            {
                attendees.Add(new Attendee()
                {
                    type = "required",
                    emailAddress = new EmailAddress()
                    {
                        name = s.displayName,
                        address = s.mail
                    }
                });
            }
            req.attendees = attendees;

            // time constraint
            var timeSlots = new List<Timeslot>();
            timeSlots.Add(DateHelper.GetNextMeetingTimeslot());
            var tc = new TimeConstraint()
            {
                activityDomain = "unrestricted",
                timeslots = timeSlots
            };
            req.timeConstraint = tc;

            // timespan
            var timeSpan = TimeSpan.FromMinutes(duration);
            req.meetingDuration = XmlConvert.ToString(timeSpan);

            return req;
        }
    }
}