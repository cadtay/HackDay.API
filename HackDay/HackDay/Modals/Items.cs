using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackDay.Modals
{
    public class Items
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("eaAreaName")]
        public string EaAreaName { get; set; }
        [JsonProperty("eaRegionName")]
        public string EaRegionName { get; set; }
        [JsonProperty("severity")]
        public string Severity { get; set; }
        [JsonProperty("severityLevel")]
        public int SeverityLevel { get; set; }
        [JsonProperty("timeRaised")]
        public DateTime TimeRaised { get; set; }
        [JsonProperty("timeSeverityChanged")]
        public DateTime TimeSeverityChanged { get; set; }
    }
}
