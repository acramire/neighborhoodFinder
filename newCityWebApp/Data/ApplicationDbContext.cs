using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newCityWebApp.Models;

namespace newCityWebApp.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<newCityWebApp.Models.Joke> Joke { get; set; } = default!;
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Don't forget this call!

        modelBuilder.Entity<Submission>()
            .HasOne(s => s.User) // Submission has one User
            .WithMany(u => u.Submissions) // User has many Submissions
            .HasForeignKey(s => s.UserId); // Foreign key on Submission.UserId
    }
}

