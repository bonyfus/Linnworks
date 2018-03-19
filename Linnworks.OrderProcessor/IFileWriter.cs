using System.Collections.Generic;
using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public interface IFileWriter
    {
        void Write(List<OrderOutput> orderOutputs, string location, string fileName);
    }
}
