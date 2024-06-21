namespace Repositories.Dto
{
    public class OrderFixedItemStock
    {

        public int OrderId { get; set; }

        public int ProductStockId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }
    }
}
