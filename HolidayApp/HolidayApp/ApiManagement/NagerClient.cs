using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayApp.ApiManagement
{
    public class NagerClient
    {
        private ApiClient _apiClient;

        public NagerClient()
        {
            _apiClient = new ApiClient("https://date.nager.at/Api/v2/");            
        }

        public Task<List<NagerCountry>> GetAvailableCountriesAsync()
        {
            return _apiClient.GetAsync<List<NagerCountry>>("AvailableCountries");
        }
    }
}
