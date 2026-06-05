using HealthClaimPro.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthClaimPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ApprovalHistory> ApprovalHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Claim → ApprovalHistory (one to many)
            modelBuilder.Entity<ApprovalHistory>()
                .HasOne(a => a.Claim)
                .WithMany(c => c.ApprovalHistories)
                .HasForeignKey(a => a.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            // User → ApprovalHistory (one to many)
            modelBuilder.Entity<ApprovalHistory>()
                .HasOne(a => a.User)
                .WithMany(u => u.ApprovalHistories)
                .HasForeignKey(a => a.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique email for users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}