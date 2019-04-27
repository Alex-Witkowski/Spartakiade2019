using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidayApp.Api
{
    public class Client
    {
        HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://date.nager.at/Api/v2/");
        }

        public async Task<Country[]> GetAvailableCountries()
        {
            var result = await _httpClient.GetStringAsync("AvailableCountries");
            var countries = JsonConvert.DeserializeObject<Country[]>(result);

            return countries;
        }


    }

    public class Country
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
