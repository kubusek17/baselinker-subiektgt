using Newtonsoft.Json;

namespace SellIntegro.OrderProcessor.Models
{
    internal class Product
    {
        [JsonProperty("order_product_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("tax_rate")]
        public int TaxRate { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        [JsonProperty("price_brutto")]
        public decimal Price { get; set; }

    }
}
