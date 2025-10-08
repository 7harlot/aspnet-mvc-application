using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_1.Models;

public class Purchase
{
    public int PurchaseId { get; set; }

    [Required]
    public DateTime PurchaseDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCost { get; set; }

    // Guest information
    [Required]
    [StringLength(100)]
    public string GuestName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string GuestEmail { get; set; } = string.Empty;

    // Navigation property
    public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}