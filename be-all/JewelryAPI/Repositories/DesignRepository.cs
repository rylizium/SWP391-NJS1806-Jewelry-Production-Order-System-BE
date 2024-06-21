using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Repositories.Models;
using System.ComponentModel.Design;


namespace Repositories
{
    public class DesignRepository
    {
       private JeweleryOrderProductionContext _context;
       private readonly IMapper _mapper;

        public DesignRepository(JeweleryOrderProductionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Design> GetDesigns()
        {
            
            var designs = _context.Designs.ToList();

            return designs;
        }

        public ICollection<Design> GetDesignsByCusId(int custId)
       
        {
         return _context.Designs.Where(d => d.Order.CustomerId == custId).ToList();
                            
        }

        public bool UpdateDesign(Design design)
        {
             _context.Designs.Update(design);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

      
    }
}
