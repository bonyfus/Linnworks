using System.Collections.Generic;
using Newtonsoft.Json;

namespace Linnworks.OrderProcessor.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems=new List<OrderItem>();
        }
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }
        [JsonProperty(PropertyName = "marketplace")]
        public string MarketPlace { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }


        [JsonProperty(PropertyName = "order items")]
        public List<OrderItem> OrderItems { get; set; }

        public OrderShipment OrderShipment { get; set; }
    }
    }
