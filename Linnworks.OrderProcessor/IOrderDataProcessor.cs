using System.Collections.Generic;
using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public interface IOrderDataProcessor
    {
        List<OrderOutput> BuildOrderOutput(Order order);
        List<Order> GenerateOrderObjects(RootObject processingObject);
    }
}
