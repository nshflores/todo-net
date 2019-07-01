using Microsoft.EntityFrameworkCore;

namespace todo_api.Entities {
  public class TodoContext: DbContext {
    public DbSet<Task> Tasks { get; set; }

    public TodoContext (DbContextOptions<TodoContext> options): base(options) {}

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      Task[] tasks = new[] {
        new Task ("Tarea 1"),
        new Task ("Tarea 2"),
        new Task ("Tarea 3"),
      };

      modelBuilder.Entity<Task>().HasData(tasks);
    }
  }
}