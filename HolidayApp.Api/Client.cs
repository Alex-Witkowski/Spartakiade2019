using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HolidayApp.Api
{
    public class Client
    {
        RestClient _httpClient;

        public Client()
        {
            _httpClient = new RestClient("https://date.nager.at/Api/v2/");
        }

        public async Task<List<Country>> GetAvailableCountries()
        {
            var request = new RestRequest("AvailableCountries", DataFormat.Json);

            return await _httpClient.GetAsync<List<Country>>(request);
        }

        public async Task<List<Holiday>> GetPublicHolidays(int year, string countryCode)
        {
            var request = new RestRequest("PublicHolidays/{year}/{countryCode}", DataFormat.Json);
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("countryCode", countryCode, ParameterType.UrlSegment);

            return await _httpClient.GetAsync<List<Holiday>>(request);
        }

        public async Task<List<Weekend>> GetLongWeekends(int year, string countryCode)
        {
            var request = new RestRequest("LongWeekend/{year}/{countryCode}", DataFormat.Json);
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("countryCode", countryCode, ParameterType.UrlSegment);

            return await _httpClient.GetAsync<List<Weekend>>(request);
        }
    }

    public class Country
    {
        public string key { get; set; }
        public string value { get; set; }
    }


    public class Holiday
    {
        public DateTime date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public bool _fixed { get; set; }
        public bool global { get; set; }
        public string[] counties { get; set; }
        public int launchYear { get; set; }
        public int type { get; set; }
    }


    public class Weekend
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int dayCount { get; set; }
        public bool needBridgeDay { get; set; }
    }

}
