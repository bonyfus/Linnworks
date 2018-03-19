using Linnworks.OrderProcessor.Models;
using Newtonsoft.Json;

namespace Linnworks.OrderProcessor
{
    class JsonDeserializer : IDeserializer
    {
        public RootObject Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<RootObject>(content);
        }
    }
}
