using Newtonsoft.Json;

namespace Linnworks.OrderProcessor.Models
{
    public class OrderItem
    {
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }
        [JsonProperty(PropertyName = "marketplace")]
        public string MarketPlace { get; set; }
        [JsonProperty(PropertyName = "order item number")]
        public object OrderItemNumber { get; set; }
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }
        [JsonProperty(PropertyName = "price per unit")]
        public decimal PricePerUnit { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
