using Microsoft.EntityFrameworkCore;

using (var dbContext = new MyDbContext())
{
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    var taskA = new TaskA { Name = "Task A", RandomProp = 123, TaskAProp = 2 };
    var taskB = new TaskB { Name = "Task B", RandomProp = 123, TaskBProp = 415 };

    dbContext.Tasks.Add(taskA);
    dbContext.Tasks.Add(taskB);

    dbContext.SaveChanges();

    var list = dbContext.Tasks.ToList();
}



public class MyDbContext : DbContext
{
    public DbSet<TaskBase> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskBase>()
            .HasDiscriminator<string>("task_type")
            .HasValue<TaskA>("a")
            .HasValue<TaskB>("b");

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TBH_test;MultipleActiveResultSets=true;Integrated Security=True;Encrypt=False;");

        base.OnConfiguring(optionsBuilder);
    }
}


public abstract class TaskBase
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class TaskA : TaskBase
{
    public int RandomProp { get; set; }
    public int TaskAProp { get; set; }
}

public class TaskB : TaskBase
{
    public int RandomProp { get; set; }
    public int TaskBProp { get; set; }
}