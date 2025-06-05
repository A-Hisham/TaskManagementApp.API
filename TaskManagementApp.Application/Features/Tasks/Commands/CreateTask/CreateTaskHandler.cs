using AutoMapper;
using MediatR;
using TaskManagementApp.Domain;

namespace TaskManagementApp.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler :IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public CreateTaskHandler (ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = _mapper.Map<Domain.Task>(request.Task);
            await _repository.AddAsync(taskEntity);
            return taskEntity.Id;
        }
    }
}
