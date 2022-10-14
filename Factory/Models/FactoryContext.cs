using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {

    public DbSet<Player> Players { get; set;}
    public DbSet<Sport> Sports { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<SemesterSport> SemesterSport { get; set; }
    public DbSet<SportPlayer> SportPlayer { get; set; }
    public DbSet<SemesterPlayer> SemesterPlayer { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}