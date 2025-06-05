using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Features.Tasks.Queries.GetTaskById
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskDTO>;
}
