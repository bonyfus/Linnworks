using System.Collections.Generic;
using System.Linq;
using Linnworks.OrderProcessor.Models;

namespace Linnworks.OrderProcessor
{
    public class OrderDataProcessor : IOrderDataProcessor
    {
        public List<OrderOutput> BuildOrderOutput(Order order)
        {
            var orderOutput = new List<OrderOutput>();
            foreach (var orderItem in order.OrderItems)
            {
                orderOutput.Add(new OrderOutput
                {
                    OrderReference = order.OrderReference,
                    MarketPlace = orderItem.MarketPlace,
                    OrderItemNumber = orderItem.OrderItemNumber,
                    Name = order.Name,
                    Surname = order.Surname,
                    Sku = orderItem.Sku,
                    PricePerUnit = orderItem.PricePerUnit,
                    Quantity = orderItem.Quantity,
                    PostalService = order.OrderShipment.PostalService,
                    Postcode = order.OrderShipment.Postcode
                });
            }

            return orderOutput;
        }

        public List<Order> GenerateOrderObjects(RootObject processingObject)
        {
            if (processingObject.Orders == null)
                return null;

            var orders = processingObject.Orders;

            foreach (var order in orders.ToList())
            {
                foreach (var orderItem in processingObject.OrderItems)
                {
                    if (order.OrderReference == orderItem.OrderReference)
                        order.OrderItems.Add(orderItem);
                }

                foreach (var orderShipment in processingObject.OrderShipments)
                {
                    if (order.OrderReference == orderShipment.OrderReference)
                        order.OrderShipment = orderShipment;
                }

                if (order.OrderItems.Count == 0 || order.OrderShipment == null)
                {
                    orders.Remove(order);
                }
            }

            return orders;
        }

    }
}
