﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mebo_calendar_api.Models
{
    public class AuthModels
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string access_token { get; set; }
    }
}