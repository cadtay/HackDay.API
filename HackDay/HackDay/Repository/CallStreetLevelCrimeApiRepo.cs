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
        // Default Locations & Date
        private readonly string _defaultLocationOne = "lat=52.267136&lng=-1.467522";
        private readonly string _defaultLocationTwo = "lat=51.8931874&lng=-2.1195963";
        private readonly string _defaultLocationThree = "lat=52.4131949=lng-1.7247352";
        private readonly string _defaultLocationFour = "#";
        private readonly string _defaultDate = "2020-06";

        /******************************************************************************/
        private IHttpClientFactory _clientFactory;
        private StreetLevelCrimes[] _streetLevelCrimes;

        public CallStreetLevelCrimeApiRepo(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<StreetLevelCrimes[]> GetAllStreetLevelCrimesByLocationAndTime(string date)
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
            else
            {
                return null;
            }
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
            else
            {
                return null;
            }
        }
    }
}
