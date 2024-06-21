using AutoMapper;
using Microsoft.EntityFrameworkCore;


using Repositories.Dto;
using Repositories.Models;
using System.Runtime.InteropServices;

namespace Repositories
{
    public class OrderCustomItemRepository 
    {
        private JeweleryOrderProductionContext _context;
   
        private readonly IMapper _mapper;

        public OrderCustomItemRepository(JeweleryOrderProductionContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            
            _mapper = mapper;
        }

        public ICollection<OrderCuSDto> GetAllOrderCustomItems()
        {
            var  orderCustomItems = from p in _context.OrderCustomItems
                                    join m in _context.Metals on p.MetalId equals m.MetalId
                                    join g in _context.Gemstones on p.GemstoneId equals g.GemstoneId
                                    select new OrderCuSDto
                                    {
                                        OrderItemId = p.OrderItemId,
                                        OrderId = p.OrderId,
                                        GemstoneId = p.GemstoneId,
                                        GemstoneType = g.GemstoneType,
                                        MetalId = p.MetalId,
                                        MetalTypeName = m.MetalTypeName,
                                        Size = p.Size,
                                        UnitPrice = p.UnitPrice,
                                        Quantity = p.Quantity,

                                        
                                    };
            List<OrderCuSDto> returnList = orderCustomItems.ToList();
            return returnList;
        }

        public OrderCuSDto? GetOrderCustomItemByOrderId(int orderItemId)

        {
            var orderCustomItems = from p in _context.OrderCustomItems
                                   join m in _context.Metals on p.MetalId equals m.MetalId
                                   join g in _context.Gemstones on p.GemstoneId equals g.GemstoneId
                                   select new OrderCuSDto
                                   {
                                       OrderItemId = p.OrderItemId,
                                       OrderId = p.OrderId,
                                       GemstoneId = p.GemstoneId,
                                       GemstoneType = g.GemstoneType,
                                       MetalId = p.MetalId,
                                       MetalTypeName = m.MetalTypeName,
                                       Size = p.Size,
                                       UnitPrice = p.UnitPrice,
                                       Quantity = p.Quantity,


                                   };
           return orderCustomItems.Where(oci => oci.OrderItemId == orderItemId).FirstOrDefault();
     

        }

        public bool UpdateOrderCustomItem(OrderCuSDto orderCustomItem)
        {
            var orderCustomItems = from p in _context.OrderCustomItems
                                   join m in _context.Metals on p.MetalId equals m.MetalId
                                   join g in _context.Gemstones on p.GemstoneId equals g.GemstoneId
                                   select new OrderCuSDto
                                   {
                                       OrderItemId = p.OrderItemId,
                                       OrderId = p.OrderId,
                                       GemstoneId = p.GemstoneId,
                                       GemstoneType = g.GemstoneType,
                                       MetalId = p.MetalId,
                                       MetalTypeName = m.MetalTypeName,
                                       Size = p.Size,
                                       UnitPrice = p.UnitPrice,
                                       Quantity = p.Quantity,


                                   };
            _context.OrderCustomItems.Update(_mapper.Map<OrderCustomItem>(orderCustomItem));
            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
            
        }
        
        public bool DeleteOrderCustomItem(OrderCuSDto orderItemId)
        {
            var orderCustomItems = from p in _context.OrderCustomItems
                                   join m in _context.Metals on p.MetalId equals m.MetalId
                                   join g in _context.Gemstones on p.GemstoneId equals g.GemstoneId
                                   select new OrderCuSDto
                                   {
                                       OrderItemId = p.OrderItemId,
                                       OrderId = p.OrderId,
                                       GemstoneId = p.GemstoneId,
                                       GemstoneType = g.GemstoneType,
                                       MetalId = p.MetalId,
                                       MetalTypeName = m.MetalTypeName,
                                       Size = p.Size,
                                       UnitPrice = p.UnitPrice,
                                       Quantity = p.Quantity,


                                   };
            _context.OrderCustomItems.Remove(_mapper.Map<OrderCustomItem>(orderItemId));
            return Save();
        }

        public bool IsOrderCustomItemExist(int orderItemId)
        {
            return _context.OrderCustomItems.Any(oci => oci.OrderItemId == orderItemId);
        }

        public bool AddOrderCustomItem(OrderCuSDto orderCustomItem)
        {
            var orderCustomItems = from p in _context.OrderCustomItems
                                   join m in _context.Metals on p.MetalId equals m.MetalId
                                   join g in _context.Gemstones on p.GemstoneId equals g.GemstoneId
                                   select new OrderCuSDto
                                   {
                                       OrderItemId = p.OrderItemId,
                                       OrderId = p.OrderId,
                                       GemstoneId = p.GemstoneId,
                                       GemstoneType = g.GemstoneType,
                                       MetalId = p.MetalId,
                                       MetalTypeName = m.MetalTypeName,
                                       Size = p.Size,
                                       UnitPrice = p.UnitPrice,
                                       Quantity = p.Quantity,
                                   };
        _context.OrderCustomItems.Add(_mapper.Map<OrderCustomItem>(orderCustomItem));
            return Save();
        }
    }
}
