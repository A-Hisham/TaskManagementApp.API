using AutoMapper;
using MediatR;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Features.Tasks.Queries.GetTaskById;
using TaskManagementApp.Domain;

namespace TaskManagementApp.Application.Features.Tasks.Queries.GetTaskByIdHandler
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDTO>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            return task == null ? null : _mapper.Map<TaskDTO>(task);
        }
    }
}
