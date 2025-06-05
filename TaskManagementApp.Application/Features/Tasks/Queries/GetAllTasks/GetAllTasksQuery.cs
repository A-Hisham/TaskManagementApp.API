using MediatR;
using TaskManagementApp.Application.DTOs;

namespace TaskManagementApp.Application.Features.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery() : IRequest<List<TaskDTO>>;
}
