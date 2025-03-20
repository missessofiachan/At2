#region

using At2.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace At2.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Applicant> Applicants => Set<Applicant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.ToTable("Applicants", "hr");
            entity.HasKey(e => e.ApplicantId);
            entity.Property(e => e.ApplicantId).UseIdentityColumn();
        });
    }
}