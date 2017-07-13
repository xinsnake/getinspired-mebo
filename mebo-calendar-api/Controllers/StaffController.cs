using mebo_calendar_api.Helpers;
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
    public class StaffController : ApiController
    {
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                var accessToken = await ServiceAuthProvider.GetAccessToken();
                var staff = await GraphService.GetStaff(accessToken);
                return Ok(staff);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
