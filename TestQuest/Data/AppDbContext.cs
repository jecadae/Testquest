using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using TestQuest.Entity;

namespace TestQuest;
/// <summary>
/// Контекст данных 
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("DefaultConnection");
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Skill> Skills { get; set; }
}