using TaskManagementApp.Application;
using TaskManagementApp.Domain;
using DomainTask = TaskManagementApp.Domain.Task;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<DomainTask>> GetAllTasksAsync()
    {
        return await _taskRepository.GetAllAsync();
    }

    public async Task<DomainTask> GetTaskByIdAsync(int id)
    {
        return await _taskRepository.GetByIdAsync(id);
    }

    public async Task<int> CreateTaskAsync(DomainTask task)
    {
        return await _taskRepository.AddAsync(task);
    }

    public async Task<int> UpdateTaskAsync(DomainTask task)
    {
        // Example validation: Check if task exists before updating
        var existingTask = await _taskRepository.GetByIdAsync(task.Id);
        if (existingTask == null)
        {
            throw new KeyNotFoundException("Task not found.");
        }
        return await _taskRepository.UpdateAsync(task);
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        return await _taskRepository.DeleteAsync(id);
    }
}