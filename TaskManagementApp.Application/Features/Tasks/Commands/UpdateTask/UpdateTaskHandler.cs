using AutoMapper;
using MediatR;
using TaskManagementApp.Domain;

namespace TaskManagementApp.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _repository.GetByIdAsync(request.Id);
            if (existingTask == null)
            {
                return -1;
            }
            
            _mapper.Map(request.Task, existingTask);
            return await _repository.UpdateAsync(existingTask);
        }
    }
}
