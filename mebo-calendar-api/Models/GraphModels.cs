using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Models
{
    public class UserResponse
    {
        public IEnumerable<User> value { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string givenName { get; set; }
        public string jobTitle { get; set; }
        public string mail { get; set; }
        public string mobilePhone { get; set; }
        public string officeLocation { get; set; }
        public string preferredLanguage { get; set; }
        public string surname { get; set; }
        public string userPrincipalName { get; set; }
    }
}