using Microsoft.EntityFrameworkCore;
using ResultPattern.Domain.Models;

namespace ResultPattern.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Email).IsRequired();
            b.Property(x => x.FullName).IsRequired();
            b.Property(x => x.AvatarUrl).IsRequired(false);
        });
    }
}
