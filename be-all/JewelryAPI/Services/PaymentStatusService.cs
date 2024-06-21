

using AutoMapper;
using Repositories;
using Repositories.Models;

namespace Services;

public class PaymentStatusService
{
    private PaymentStatusRepository _repository;
    private readonly IMapper _mapper;

        public PaymentStatus GetPaymentStatusById(int paymentStatusId)
        {
            _repository = new PaymentStatusRepository(_mapper);
            return _repository.GetPaymentStatusById(paymentStatusId);
        }
}
