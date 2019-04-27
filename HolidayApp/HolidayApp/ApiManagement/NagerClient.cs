using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayApp.ApiManagement
{
    public class NagerClient
    {
        private ApiClient _apiClient;

        private readonly string _v1 = "https://date.nager.at/Api/v1/";
        private readonly string _v2 = "https://date.nager.at/Api/v2/";


        public NagerClient()
        {
            _apiClient = new ApiClient("https://date.nager.at/Api/v2/");            
        }

        public Task<List<NagerCountry>> GetAvailableCountriesAsync()
        {
            _apiClient.SetBaseUrl(_v2);

            return _apiClient.GetAsync<List<NagerCountry>>("AvailableCountries");
        }

        public Task<List<NagerHoliday>> GetHolidaysAsync(string countryCode, string year)
        {
            _apiClient.SetBaseUrl(_v1);

            return _apiClient.GetAsync<List<NagerHoliday>>($"Get/{countryCode}/{year}");
        }
    }
}
