using AutoMapper;
using Repositories.Models;


namespace Repositories
{
    public class PaymentStatusRepository 
    {
        private JeweleryOrderProductionContext _context;
        private readonly IMapper _mapper;

        public PaymentStatusRepository(IMapper mapper)
        {
            _context = new JeweleryOrderProductionContext();
            _mapper = mapper;
        }

        public PaymentStatus GetPaymentStatusById(int paymentStatusId)
        {
            return _context.PaymentStatuses.Where(p => p.PaymentStatusId == paymentStatusId).FirstOrDefault();
        }
    }
}
