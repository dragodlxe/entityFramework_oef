using Microsoft.EntityFrameworkCore;

namespace oefproject
{
    public class TasksContext : DbContext
    {
        public DbSet<models.Category> Categories { set; get; }
        public DbSet<models.Task> Tasks { set; get; }
        
        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            List<models.Category> CategoriesInit =  new List<models.Category>();
            CategoriesInit.Add(new models.Category() { CategoryId = Guid.Parse("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"), Name = "Pending tasks", Weignt = 20 });
            CategoriesInit.Add(new models.Category() { CategoryId = Guid.Parse("f53b5019-1a13-489d-86bb-28160188dbd9"), Name = "Personal tasks", Weignt = 50 });
            modelBuilder.Entity<models.Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description).IsRequired(false);
                category.Property(p=> p.Weignt);
                category.HasData(CategoriesInit);
            });
            List<models.Task> TasksInit = new List<models.Task>();
            TasksInit.Add(new models.Task() {TaskId = Guid.Parse("f2c40001-6c9a-43a4-aeb3-cc7902499e2e"), CategoryId = Guid.Parse("e97a59f5-b85a-4fcd-9f09-f869a5e5863b"), TaskPriority = models.Priority.Mid, Title = "Payment due public services", CreateDt = DateTime.Now});
            TasksInit.Add(new models.Task() {TaskId = Guid.Parse("cd12ffd5-c35c-45a6-ba43-013d2402b498"), CategoryId = Guid.Parse("f53b5019-1a13-489d-86bb-28160188dbd9"), TaskPriority = models.Priority.Low, Title = "Finish movie on netflix", CreateDt = DateTime.Now});
            modelBuilder.Entity<models.Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p=> p.CreateDt);
                task.Property(p => p.TaskPriority).HasConversion(
                    p => p.ToString(),
                    p => (models.Priority)Enum.Parse(typeof(models.Priority), p)
                );
                task.Ignore(p => p.Summary);
                task.HasData(TasksInit);
            });
        }
    }
}