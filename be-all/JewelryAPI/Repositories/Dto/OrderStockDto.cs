namespace SWP3.Dto
{
    public class OrderStockDto
    {


        public int CustomerId { get; set; }

        public DateOnly OrderDate { get; set; }

        public int StatusId { get; set; }

        public int PaymentStatusId { get; set; }

        public bool IsShipment { get; set; }

        public bool IsCustom { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
