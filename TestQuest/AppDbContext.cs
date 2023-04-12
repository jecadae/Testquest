using Microsoft.EntityFrameworkCore;
using TestQuest.Entity;

namespace TestQuest;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testappdb;Trusted_Connection=True;");
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Skill> Skills { get; set; }
}