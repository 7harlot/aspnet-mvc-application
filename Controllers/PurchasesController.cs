using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment_1.Data;
using assignment_1.Models;

namespace assignment_1.Controllers;

public class PurchasesController : Controller
{
    private readonly ApplicationDbContext _context;

    public PurchasesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Purchases/SelectEvent
    public async Task<IActionResult> SelectEvent()
    {
        var availableEvents = await _context.Events
            .Include(e => e.Category)
            .Where(e => e.AvailableTickets > 0)
            .OrderBy(e => e.DateTime)
            .ToListAsync();

        return View(availableEvents);
    }

    // GET: Purchases/Create?eventId=1
    public async Task<IActionResult> Create(int? eventId)
    {
        if (eventId == null)
        {
            return RedirectToAction(nameof(SelectEvent));
        }

        var eventItem = await _context.Events
            .Include(e => e.Category)
            .FirstOrDefaultAsync(e => e.EventId == eventId);

        if (eventItem == null || eventItem.AvailableTickets == 0)
        {
            return NotFound();
        }

        var viewModel = new PurchaseCreateViewModel
        {
            Event = eventItem,
            Quantity = 1
        };

        return View(viewModel);
    }

    // POST: Purchases/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PurchaseCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Event = await _context.Events
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.EventId == model.EventId);
            return View(model);
        }

        var eventItem = await _context.Events.FindAsync(model.EventId);
        if (eventItem == null)
        {
            return NotFound();
        }

        // Validate ticket availability
        if (model.Quantity > eventItem.AvailableTickets)
        {
            ModelState.AddModelError("Quantity", $"Only {eventItem.AvailableTickets} tickets available.");
            model.Event = await _context.Events
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.EventId == model.EventId);
            return View(model);
        }

        // Create purchase
        var purchase = new Purchase
        {
            PurchaseDate = DateTime.UtcNow,
            TotalCost = model.Quantity * eventItem.TicketPrice,
            GuestName = model.GuestName,
            GuestEmail = model.GuestEmail
        };

        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();

        // Create purchase item
        var purchaseItem = new PurchaseItem
        {
            PurchaseId = purchase.PurchaseId,
            EventId = eventItem.EventId,
            Quantity = model.Quantity,
            PricePerTicket = eventItem.TicketPrice
        };

        _context.PurchaseItems.Add(purchaseItem);

        // Update available tickets
        eventItem.AvailableTickets -= model.Quantity;
        _context.Update(eventItem);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Confirmation), new { id = purchase.PurchaseId });
    }

    // GET: Purchases/Confirmation/5
    public async Task<IActionResult> Confirmation(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var purchase = await _context.Purchases
            .Include(p => p.PurchaseItems)
            .ThenInclude(pi => pi.Event)
            .ThenInclude(e => e.Category)
            .FirstOrDefaultAsync(p => p.PurchaseId == id);

        if (purchase == null)
        {
            return NotFound();
        }

        return View(purchase);
    }
}