using AutoMapper;

using SWP3.Interface;

using SWP3.Models;

namespace SWP1.Repositories
{
    public class OrderFixedItemRepository : IOrderFixedItems
    {
        private JeweleryOrderProductionContext _context;
        private readonly IMapper _mapper;

        public OrderFixedItemRepository(JeweleryOrderProductionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<OrderFixedItem> GetAllFixedItems()
        { 

           var orderFixedItems = _context.OrderFixedItems.ToList();
            return orderFixedItems;
            
            
        }

        public OrderFixedItem GetFixedItemByOrderId(int index)
        {
            var orderFixedItem = _context.OrderFixedItems.Where(o => o.OrderId == index).FirstOrDefault();
            return orderFixedItem;
        }

        public bool AddFixedItem(OrderFixedItem orderFixedItems)
        { 

          

            _context.OrderFixedItems.Add(orderFixedItems);
   
           return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateFixedItem(OrderFixedItem orderFixedItem)
        {
            _context.OrderFixedItems.Update(orderFixedItem);
            return Save();
        }

        public bool DeleteFixedItem(OrderFixedItem orderFixedItem)
        {
            _context.OrderFixedItems.Remove(orderFixedItem);    
            return Save();
        }

        public OrderFixedItem GetFixedItemById(int index)
        {
            var orderFixedItem = _context.OrderFixedItems.Where(o => o.OrderFixedItemId == index).FirstOrDefault();
            return orderFixedItem;
        }
    }
}
