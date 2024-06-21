using Repositories.Models;

namespace Repositories.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateOnly OrderDate { get; set; }

        public int StatusId { get; set; } 

        public int PaymentStatusId { get; set; }

        public bool IsShipment { get; set; }

        public bool IsCustom { get; set; }

        public decimal OrderTotal { get; set; }

        public virtual CustomerDetail Customer { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; } = null!;
    }
}
