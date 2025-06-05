using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Features.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand(CreateTaskDTO Task) : IRequest<int>;
}
