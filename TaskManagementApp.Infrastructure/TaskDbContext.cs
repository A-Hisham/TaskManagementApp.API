namespace TaskManagementApp.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using TaskManagementApp.Domain;

    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations if needed
        }
    }
}
