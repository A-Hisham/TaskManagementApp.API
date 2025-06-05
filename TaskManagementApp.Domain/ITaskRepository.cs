namespace TaskManagementApp.Domain
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllAsync();
        Task<Task> GetByIdAsync(int id);
        Task<int> AddAsync(Task task);
        Task<int> UpdateAsync(Task task);
        Task<bool> DeleteAsync(int id);
    }
}
