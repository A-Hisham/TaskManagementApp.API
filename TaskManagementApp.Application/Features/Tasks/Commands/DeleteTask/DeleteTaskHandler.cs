
using MediatR;
using TaskManagementApp.Application.Features.Tasks.Commands.DeleteTask;
using TaskManagementApp.Domain;

namespace TaskManagementApp.Application.Features.Tasks.Commands.CreateTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskHandler(ITaskRepository repository)
        {
            _repository = repository;;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
            {
                return false;
            }

            var deleteResult = await _repository.DeleteAsync(request.Id);
            return deleteResult;
        }
    }
}
