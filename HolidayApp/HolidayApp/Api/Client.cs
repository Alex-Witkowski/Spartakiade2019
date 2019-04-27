using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HolidayApp.Api
{
    public class Client
    {
        private HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://date.nager.at/api/v2/");
        }

        public async Task<Country[]> GetAvailableCountriesAsync()
        {
            var result = await _httpClient.GetStringAsync("AvailableCountries");
            return JsonConvert.DeserializeObject<Country[]>(result);
        }
    }


    public class Country
    {
        public string key { get; set; }
        public string value { get; set; }
    }

}
