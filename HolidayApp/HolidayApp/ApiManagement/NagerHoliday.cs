using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayApp.ApiManagement
{
    public class NagerHoliday
    {
        public string date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        [JsonProperty("fixed")]
        public bool isfixed { get; set; }
        public bool global { get; set; }
        public List<string> counties { get; set; }
        public int launchYear { get; set; }
        public string type { get; set; }
    }
}
