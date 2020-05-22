using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellIntegro.OrderProcessor.Models
{
    internal class Data
    {
        public string Status { get; set; }
        public List<Order> Orders { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
