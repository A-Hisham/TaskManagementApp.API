using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Domain;
using DomainTask = TaskManagementApp.Domain.Task;

namespace TaskManagementApp.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DomainTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<DomainTask> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<int> AddAsync(DomainTask task)
        {
            _context.Tasks.Add(task);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(DomainTask task)
        {
            _context.Tasks.Update(task);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            } 
                
        }

        
    }
}
