using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP3.Interface;

using SWP3.Models;


namespace SWP1.Repositories
{
    public class OrderRepository : IOrder
    {
        private JeweleryOrderProductionContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(JeweleryOrderProductionContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ICollection<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
            
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public bool AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
           return Save();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            return Save();
        }

        public bool DeleteOrder(Order orderId)
        {
            _dbContext.Orders.Remove(orderId);
            return Save();
        }
    }
}
