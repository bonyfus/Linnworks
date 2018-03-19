using System.Collections.Generic;
using System.IO;
using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public class DiskFileReader : IFileReader
    {
        private readonly IDeserializer _fileDeserializer;
        public DiskFileReader(IDeserializer fileDeserializer)
        {
            _fileDeserializer = fileDeserializer;
        }
        public RootObject Read(string location, string fileType)
        {
            var rootObject = new RootObject
            {
                OrderItems = new List<OrderItem>(),
                Orders = new List<Order>(),
                OrderShipments = new List<OrderShipment>()
            };

            foreach (var file in Directory.EnumerateFiles(location, "*." + fileType))
            {
                var content = File.ReadAllText(file);

                var tempObject = _fileDeserializer.Deserialize(content);

                if (tempObject.OrderItems != null)
                {
                    rootObject.OrderItems.AddRange(tempObject.OrderItems);
                }

                if (tempObject.OrderShipments != null)
                {
                    rootObject.OrderShipments.AddRange(tempObject.OrderShipments);
                }

                if (tempObject.Orders != null)
                {
                    rootObject.Orders.AddRange(tempObject.Orders);
                }
            }

            return rootObject;
        }
    }
}
