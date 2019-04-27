using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayApp.ApiManagement
{
    public class NagerClient
    {
        private ApiClient _apiClient;
        
        private readonly string _v2 = "https://date.nager.at/Api/v2/";


        public NagerClient()
        {
            _apiClient = new ApiClient(_v2);            
        }

        public Task<List<NagerCountry>> GetAvailableCountriesAsync()
        {
            return _apiClient.GetAsync<List<NagerCountry>>("AvailableCountries");
        }

        public Task<List<NagerHoliday>> GetHolidaysAsync(string countryCode, string year)
        {
            return _apiClient.GetAsync<List<NagerHoliday>>($"PublicHolidays/{countryCode}/{year}");
        }

        public Task<List<NagerHoliday>> GetNextPublicHolidaysAsync(string countryCode)
        {
            return _apiClient.GetAsync<List<NagerHoliday>>($"NextPublicHolidays/{countryCode}");
        }

        public Task<List<NagerHoliday>> GetNextPublicHolidaysWorldwideAsync()
        {
            return _apiClient.GetAsync<List<NagerHoliday>>($"NextPublicHolidaysWorldwide");
        }
        
        public Task<List<NagerLongWeekend>> GetLongWeekendAsync(string countryCode, string year)
        {
            return _apiClient.GetAsync<List<NagerLongWeekend>>($"LongWeekend/{year}/{countryCode}");
        }
    }
}
