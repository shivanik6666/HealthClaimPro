using System.ComponentModel.DataAnnotations;

namespace HealthClaimPro.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<ApprovalHistory> ApprovalHistories { get; set; }
    }

    public enum UserRole
    {
        Hospital,
        District,
        State,
        Admin
    }
}