using HackDay.Models;
using HackDay.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackDay.Repository
{
    public class CallStreetLevelCrimeApiRepo : IStreetLevelCrimesRepo
    {
        // Default Locations, Category & Date
        private readonly string _defaultLocationOne = "lat=52.267136&lng=-1.467522";
        private readonly string _defaultLocationTwo = "lat=51.8931874&lng=-2.1195963";
        private readonly string _defaultLocationThree = "lat=52.4131949=lng-1.7247352";
        private readonly string _defaultLocationFour = "#";
        private readonly string _defaultDate = "2020-06";
        private readonly string _defaultCategory = "burglary";
        /******************************************************************************/
        private IHttpClientFactory _clientFactory;
        private StreetLevelCrimes[] _streetLevelCrimes;
        private StreetLevelCrimeCategories[] _streetLevelCrimeCategories;

        public CallStreetLevelCrimeApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndCategoryAndTime()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?{_defaultCategory}&date={_defaultDate}&{_defaultLocationOne}");
            var client = _clientFactory.CreateClient("street-level-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            // https://data.police.uk/api/burglary?date=2011-08

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimes[]>(jsonString);

                return _streetLevelCrimes;
            }

            return null;
        }

        public async Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndDate()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?date={_defaultDate}&{_defaultLocationOne}");
            var client = _clientFactory.CreateClient("street-level-all-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimes[]>(jsonString);

                return _streetLevelCrimes;
            }

            return null;
        }

        public async Task<StreetLevelCrimes> GetStreetLevelCrimeById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"?{_defaultLocationOne}");
            var client = _clientFactory.CreateClient("street-level-all-crimes");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimes = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimes[]>(jsonString);
                foreach (var result in _streetLevelCrimes)
                {
                    if (result.id == id)
                    {
                        return result;
                    }
                }
                return null;
            }

            return null;
        }



        public async Task<StreetLevelCrimeCategories[]> GetStreetLevelCrimeCategories()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "?");
            var client = _clientFactory.CreateClient("street-level-crime-categories");
            HttpResponseMessage resp = await client.SendAsync(request);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                _streetLevelCrimeCategories = System.Text.Json.JsonSerializer.Deserialize<StreetLevelCrimeCategories[]>(jsonString);

                return _streetLevelCrimeCategories;
            }

            return null;
        }
    }
}
