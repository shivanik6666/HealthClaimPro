using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaimPro.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PatientName { get; set; }

        [Required]
        [MaxLength(150)]
        public string HospitalName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Concurrency control — this is your row versioning
        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Navigation property
        public ICollection<ApprovalHistory> ApprovalHistories { get; set; }
    }

    public enum ClaimStatus
    {
        Pending,
        ApprovedByDistrict,
        ApprovedByState,
        ApprovedByAdmin,
        Rejected
    }
}