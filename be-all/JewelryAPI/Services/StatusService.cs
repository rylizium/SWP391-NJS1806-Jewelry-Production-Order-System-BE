using AutoMapper;
using Repositories;
using Repositories.Models;

namespace Services;

public class StatusService
{
    private static readonly IMapper _mapper;
    private StatusRepositotory _repository = new StatusRepositotory(_mapper);

    public Status GetStatusById(int statusId)
        {
            return _repository.GetStatusById(statusId);
        }

        public ICollection<Status> GetAllStatus()
        {
            return _repository.GetAllStatus();
        }
}
