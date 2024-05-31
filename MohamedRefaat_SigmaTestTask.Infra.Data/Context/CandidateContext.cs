using Microsoft.EntityFrameworkCore;
using MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate;

namespace MohamedRefaat_SigmaTestTask.API.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.Email); // Set Email as the primary key

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(20);

                entity.Property(e => e.LinkedInProfile)
                      .HasMaxLength(200);

                entity.Property(e => e.GitHubProfile)
                      .HasMaxLength(200);

                entity.Property(e => e.Comments)
                      .IsRequired()
                      .HasMaxLength(500);

                // Add any other configurations you need
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
