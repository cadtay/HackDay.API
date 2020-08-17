using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;

namespace HackDay.Modals
{
    public class Flood
    {
        [JsonProperty("items")]
        public IEnumerable<Items> Items { get; set; }
    }
}
