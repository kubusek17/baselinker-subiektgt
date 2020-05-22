using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SellIntegro.OrderProcessor.Models
{
    internal class Order
    {
        [JsonProperty("order_id")]
        public int Id { get; set; }
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
        [JsonProperty("date_confirmed")]
        public DateTime DateConfirmed { get; set; }
        [JsonProperty("delivery_fullname")]
        public string DeliveryFullName { get; set; }

    }
}
