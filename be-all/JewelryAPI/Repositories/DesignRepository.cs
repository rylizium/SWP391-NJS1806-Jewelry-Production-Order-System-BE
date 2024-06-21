using AutoMapper;
using Microsoft.EntityFrameworkCore;

using SWP3.Interface;

using SWP3.Models;
using System.ComponentModel.Design;


namespace SWP.Repository
{
    public class DesignRepository : IDesign
    {
       private JeweleryOrderProductionContext _dbContext;
       private readonly IMapper _mapper;

        public DesignRepository(JeweleryOrderProductionContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ICollection<Design> GetDesigns()
        {
            
            var designs = _dbContext.Designs.ToList();

            return designs;
        }

        public ICollection<Design> GetDesignsByCusId(int custId)
       
        {
         return _dbContext.Designs.Where(d => d.Order.CustomerId == custId).ToList();
                            
        }

        public bool UpdateDesign(Design design)
        {
             _dbContext.Designs.Update(design);
            return Save();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

      
    }
}
