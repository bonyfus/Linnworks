using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public interface IDeserializer
    {
        RootObject Deserialize(string content);
    }
}
