using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_1.Models;

public class PurchaseItem
{
    public int PurchaseItemId { get; set; }

    [Required]
    public int PurchaseId { get; set; }

    [Required]
    public int EventId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerTicket { get; set; }

    // Navigation properties
    public Purchase Purchase { get; set; } = null!;
    public Event Event { get; set; } = null!;
}