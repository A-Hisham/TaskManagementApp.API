using AutoMapper;
using TaskManagementApp.Application.DTOs;
using DomainTask = TaskManagementApp.Domain.Task;

namespace TaskManagementApp.Application.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDTO, DomainTask>();
            CreateMap<DomainTask, TaskDTO>();
        }
    }
}
