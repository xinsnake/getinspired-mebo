using mebo_calendar_api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace mebo_calendar_api.Helpers
{
    public class ServiceAuthProvider
    {
        private const string clientId = @"06d5a16b-9ac0-4970-b146-d2df6df023ee";
        private const string clientSecret = @"SHsVLK5bxqchcAL5Gzsgi7x";
        private const string scope = @"https://graph.microsoft.com/.default";
        private const string grantType = @"client_credentials";
        private const string tokenUri = @"https://login.microsoftonline.com/69885e5c-865b-4ffa-8b3d-3775616f49d0/oauth2/v2.0/token";
        private static readonly HttpClient client = new HttpClient();

        private static AuthModels tokenResponse;

        public async static Task<string> GetAccessToken()
        {
            if (tokenResponse != null)
            {
                return tokenResponse.access_token;
            }

            var values = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "scope", scope },
                { "client_secret", clientSecret },
                { "grant_type", grantType }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(tokenUri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            tokenResponse = JsonHelper.Deserialize<AuthModels>(responseString);

            return tokenResponse.access_token;
        }
    }
}