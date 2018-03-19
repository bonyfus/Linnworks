namespace Linnworks.OrderProcessor.Models
{
    public class OrderOutput
    {
        public string OrderReference { get; set; }
        public string MarketPlace { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public object OrderItemNumber { get; set; }
        public string Sku { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public string PostalService { get; set; }
        public string Postcode { get; set; }
    }
}
