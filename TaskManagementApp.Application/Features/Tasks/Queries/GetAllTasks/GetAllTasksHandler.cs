using AutoMapper;
using MediatR;
using TaskManagementApp.Domain;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<TaskDTO>>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTasksHandler (ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TaskDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetAllAsync();
            return _mapper.Map<List<TaskDTO>>(tasks);
        }
    }
}
