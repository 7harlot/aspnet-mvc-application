using Microsoft.EntityFrameworkCore;
using assignment_1.Models;

namespace assignment_1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;
    public DbSet<PurchaseItem> PurchaseItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Category)
            .WithMany(c => c.Events)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PurchaseItem>()
            .HasOne(pi => pi.Purchase)
            .WithMany(p => p.PurchaseItems)
            .HasForeignKey(pi => pi.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PurchaseItem>()
            .HasOne(pi => pi.Event)
            .WithMany(e => e.PurchaseItems)
            .HasForeignKey(pi => pi.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Webinar", Description = "Online educational seminars and presentations" },
            new Category { CategoryId = 2, Name = "Concert", Description = "Live music performances and shows" },
            new Category { CategoryId = 3, Name = "Workshop", Description = "Interactive skill-building sessions" },
            new Category { CategoryId = 4, Name = "Conference", Description = "Professional gatherings and networking events" }
        );

        // Seed Events
        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                EventId = 1,
                Title = "Introduction to ASP.NET Core",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 10, 15, 14, 0, 0), DateTimeKind.Utc),
                TicketPrice = 29.99m,
                AvailableTickets = 100,
                CategoryId = 1
            },
            new Event
            {
                EventId = 2,
                Title = "Rock Festival 2025",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 11, 5, 19, 0, 0), DateTimeKind.Utc),
                TicketPrice = 89.99m,
                AvailableTickets = 500,
                CategoryId = 2
            },
            new Event
            {
                EventId = 3,
                Title = "Advanced C# Programming",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 10, 20, 10, 0, 0), DateTimeKind.Utc),
                TicketPrice = 49.99m,
                AvailableTickets = 50,
                CategoryId = 3
            },
            new Event
            {
                EventId = 4,
                Title = "Tech Summit 2025",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 12, 1, 9, 0, 0), DateTimeKind.Utc),
                TicketPrice = 199.99m,
                AvailableTickets = 200,
                CategoryId = 4
            },
            new Event
            {
                EventId = 5,
                Title = "Jazz Night Live",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 10, 25, 20, 0, 0), DateTimeKind.Utc),
                TicketPrice = 59.99m,
                AvailableTickets = 3,
                CategoryId = 2
            },
            new Event
            {
                EventId = 6,
                Title = "Web Development Bootcamp",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 11, 10, 9, 0, 0), DateTimeKind.Utc),
                TicketPrice = 299.99m,
                AvailableTickets = 2,
                CategoryId = 3
            },
            new Event
            {
                EventId = 7,
                Title = "Database Design Workshop",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 10, 18, 13, 0, 0), DateTimeKind.Utc),
                TicketPrice = 39.99m,
                AvailableTickets = 0,
                CategoryId = 3
            },
            new Event
            {
                EventId = 8,
                Title = "Virtual Reality in Education",
                DateTime = DateTime.SpecifyKind(new DateTime(2025, 11, 15, 15, 0, 0), DateTimeKind.Utc),
                TicketPrice = 19.99m,
                AvailableTickets = 150,
                CategoryId = 1
            }
        );
    }
}