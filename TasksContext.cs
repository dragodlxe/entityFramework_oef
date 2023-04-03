using Microsoft.EntityFrameworkCore;

namespace oefproject
{
    public class TasksContext : DbContext
    {
        public DbSet<models.Category> Categories { set; get; }
        public DbSet<models.Task> Tasks { set; get; }
        
        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    }
}