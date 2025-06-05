using MediatR;

namespace TaskManagementApp.Application.Features.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
