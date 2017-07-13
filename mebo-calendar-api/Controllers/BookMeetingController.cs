using mebo_calendar_api.Helpers;
using mebo_calendar_api.Models;
using mebo_calendar_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace mebo_calendar_api.Controllers
{
    public class BookMeetingController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] BookMeetingRequest request)
        {
            if (request.names.Length < 2 || request.duration < 15)
            {
                return BadRequest();
            }

            var accessToken = await ServiceAuthProvider.GetAccessToken();
            var staff = await GraphService.GetStaff(accessToken);

            staff = staff.Where(a => SearchHelper.IsStringInArray(a.displayName, request.names));

            var meetingRooms = await GraphService.GetMeetingRooms();

            var suggestions = new List<MeetingTimeSuggestion>();

            foreach (var m in meetingRooms)
            {
                var meetingSuggestions = await GraphService.FindMeetingTimeAsync(accessToken, m, staff);
                suggestions.AddRange(meetingSuggestions);
            }

            return Ok(suggestions);
        }
    }
}
