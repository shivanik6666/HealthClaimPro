using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaimPro.Models
{
    public class ApprovalHistory
    {
        [Key]
        public int HistoryId { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [Required]
        public int ApprovedBy { get; set; }

        [Required]
        public ApprovalAction Action { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("ClaimId")]
        public Claim Claim { get; set; }

        [ForeignKey("ApprovedBy")]
        public User User { get; set; }
    }

    public enum ApprovalAction
    {
        Approved,
        Rejected
    }
}