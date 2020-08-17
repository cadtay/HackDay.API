using HackDay.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HackDay.Repository.Interfaces;
using Newtonsoft.Json;

namespace HackDay.Repository
{
    public class StopSearchRepository : IStopSearchRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public StopSearchRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<StopSearch>> GetStopSearches()
        {
            var stopSearch = new List<StopSearch>();

            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync("https://data.police.uk/api/stops-street?lat=51.8931874&lng=-2.1195963&date=2019-05");

            if (response.IsSuccessStatusCode)
            {
                var crimeJson = await response.Content.ReadAsStringAsync();

                stopSearch = JsonConvert.DeserializeObject<List<StopSearch>>(crimeJson);

                return stopSearch;
            }
            return stopSearch;
        }
    }
}
