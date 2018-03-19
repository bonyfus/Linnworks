using Newtonsoft.Json;

namespace Linnworks.OrderProcessor.Models
{
    public class OrderShipment
    {
        [JsonProperty(PropertyName = "order reference")]
        public string OrderReference { get; set; }
        [JsonProperty(PropertyName = "marketplace")]
        public string MarketPlace { get; set; }
        [JsonProperty(PropertyName = "postal service")]
        public string PostalService { get; set; }
        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }
    }
}
