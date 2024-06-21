using AutoMapper;
using Repositories.Models;


namespace Repositories
{
    public class StatusRepositotory 
    {
        private JeweleryOrderProductionContext _context;
        private readonly IMapper _mapper;

        public StatusRepositotory(IMapper mapper)
        {
            _context = new JeweleryOrderProductionContext();
            _mapper = mapper;
        }

        public Status? GetStatusById(int statusId)
        {
            return _context.Statuses.Where(s => s.StatusId == statusId).FirstOrDefault();
        }

        public ICollection<Status> GetAllStatus()
        {
            return _context.Statuses.ToList();
        }
    }
}
