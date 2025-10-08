using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models;

public class DashboardViewModel
{
    public int TotalEvents { get; set; }
    public int TotalCategories { get; set; }
    public List<Event> LowTicketEvents { get; set; } = new();
    public List<Event> SoldOutEvents { get; set; } = new();
    public List<Event> UpcomingEvents { get; set; } = new();
}

public class PurchaseCreateViewModel
{
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Your Name")]
    public string GuestName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    [Display(Name = "Email Address")]
    public string GuestEmail { get; set; } = string.Empty;
}
