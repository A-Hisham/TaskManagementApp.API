using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Features.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(int Id, CreateTaskDTO Task) : IRequest<int>;
}
