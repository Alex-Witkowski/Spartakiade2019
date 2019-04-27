﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolidayApp.ApiManagement
{
    public class ApiClient
    {
        private HttpClient _httpClient;

        public ApiClient(string baseurl)
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(baseurl);
        }
        
        public async Task<TModel> GetAsync<TModel>(string resource)
        {
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new ArgumentException("message", nameof(resource));
            }

            var response = await _httpClient.GetAsync(resource);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<TModel>(content);

            return model;
        }
    }
}
