using mebo_calendar_api.Helpers;
using mebo_calendar_api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace mebo_calendar_api.Services
{
    public class GraphService
    {
        public async static Task<IEnumerable<User>> GetUsers(string accessToken)
        {
            string endpoint = "https://graph.microsoft.com/v1.0/users";

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
                            var userResponse = JsonHelper.Deserialize<UserResponse>(await response.Content.ReadAsStringAsync());
                            return userResponse.value;
                        }

                        throw new Exception("Error: " + response.ToString());
                    }
                }
            }
        }
    }
}