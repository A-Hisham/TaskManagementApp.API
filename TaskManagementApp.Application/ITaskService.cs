namespace TaskManagementApp.Application
{
    using DomainTask = TaskManagementApp.Domain.Task;
    public interface ITaskService
    {
        Task<IEnumerable<DomainTask>> GetAllTasksAsync();
        Task<DomainTask> GetTaskByIdAsync(int id);
        Task<int> CreateTaskAsync(DomainTask task);
        Task<int> UpdateTaskAsync(DomainTask task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
