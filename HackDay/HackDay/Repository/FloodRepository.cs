using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using HackDay.Modals;
using HackDay.Repository.Interfaces;
using Newtonsoft.Json;

namespace HackDay.Repository
{
    public class FloodRepository : IFloodRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public FloodRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Flood> GetFloodAsync(FloodViewModel floodModel)
        {
            var flood = new Flood();

            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(
                $"http://environment.data.gov.uk/flood-monitoring/id/floods?lat={floodModel.Latitude}&long={floodModel.Longitude}&dist={floodModel.Distance}");

            if (response.IsSuccessStatusCode)
            {
                var floodJson = await response.Content.ReadAsStringAsync();

                flood = JsonConvert.DeserializeObject<Flood>(floodJson);

                return flood;
            }
            return flood;
        }
    }
}
