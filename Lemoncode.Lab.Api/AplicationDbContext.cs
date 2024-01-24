namespace Lemoncode.Lab.Api.Entities;

using Microsoft.EntityFrameworkCore;



public class AplicationDbContext(DbContextOptions<AplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Participants)
            .WithMany(p => p.Events);

        modelBuilder.Entity<Event>()
            .Property(e => e.StartDate)
            .HasColumnType("date");

        modelBuilder.Entity<Event>()
            .Property(e => e.EndDate)
            .HasColumnType("date")
            .IsRequired(false)
            .HasDefaultValue(null)
            .HasAnnotation("CheckConstraint", "EndDate >= StartDate");
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
}




