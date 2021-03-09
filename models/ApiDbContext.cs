using Microsoft.EntityFrameworkCore;

public class ApiDbContext : DbContext 
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
    : base(options)
    {

    }

    public DbSet<Citizen> Citizens {get;set;}
    public DbSet<Task> Tasks {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new CitizenMap(modelBuilder.Entity<Citizen>());
        new TaskMap(modelBuilder.Entity<Task>());
    } 
}