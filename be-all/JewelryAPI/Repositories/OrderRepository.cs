using System.ComponentModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;


namespace Repositories
{
    public class OrderRepository
    {
        private JeweleryOrderProductionContext _context;
        private readonly IMapper _mapper;
        
        public OrderRepository (IMapper mapper)
        {
            _context = new JeweleryOrderProductionContext();
            _mapper = mapper;
        }
        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
            
        }

        public Order? GetOrderById(int orderId)
        {
            return _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public bool AddOrder(Order order)
        {
            _context.Orders.Add(order);
           return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            return Save();
        }

        public bool DeleteOrder(Order orderId)
        {
            _context.Orders.Remove(orderId);
            return Save();
        }
    }
}
