using System.Collections.Generic;
using Newtonsoft.Json;

namespace Linnworks.OrderProcessor.Models
{
    public class RootObject
    {
        [JsonProperty(PropertyName = "order items")]
        public List<OrderItem> OrderItems { get; set; }

        [JsonProperty(PropertyName = "order shipments")]
        public List<OrderShipment> OrderShipments { get; set; }

        [JsonProperty(PropertyName = "orders")]
        public List<Order> Orders { get; set; }
    }
}
