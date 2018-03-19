using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public interface IFileReader
    {
        RootObject Read(string location, string fileType);
    }
}
