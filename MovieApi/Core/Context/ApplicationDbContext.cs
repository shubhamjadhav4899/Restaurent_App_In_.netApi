using Microsoft.EntityFrameworkCore;
using MovieApi.Core.Entites;

namespace MovieApi.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 

        }   
        public DbSet<Compony> componies { get; set; }

        public DbSet<Job> jobs { get; set; }

        public DbSet<Candidate> candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(job => job.Compony)
                .WithMany(compony => compony.Jobs)
                .HasForeignKey(job => job.ComponyId);
            modelBuilder.Entity<Candidate>()
                .HasOne(candidate => candidate.Job)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobId);
            modelBuilder.Entity<Compony>()
                .Property(compony => compony.Size)
                .HasConversion<string>();
            modelBuilder.Entity<Job>()
                .Property(job => job.Level)
                .HasConversion<string>();
        }
    }
}
