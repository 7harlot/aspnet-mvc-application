using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment_1.Data;
using assignment_1.Models;

namespace assignment_1.Controllers;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Events
    public async Task<IActionResult> Index(int? categoryId, string? searchTerm, string? sortBy, DateTime? startDate, DateTime? endDate, string? availability)
    {
        var eventsQuery = _context.Events.Include(e => e.Category).AsQueryable();

        // Filter by category
        if (categoryId.HasValue && categoryId.Value > 0)
        {
            eventsQuery = eventsQuery.Where(e => e.CategoryId == categoryId.Value);
        }

        // Search by title or date (case-insensitive)
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.ToLower();
            eventsQuery = eventsQuery.Where(e => e.Title.ToLower().Contains(searchTerm) || e.DateTime.ToString().ToLower().Contains(searchTerm));
        }

        // Filter by date range
        if (startDate.HasValue)
        {
            eventsQuery = eventsQuery.Where(e => e.DateTime >= startDate.Value);
        }
        if (endDate.HasValue)
        {
            eventsQuery = eventsQuery.Where(e => e.DateTime <= endDate.Value);
        }

        // Filter by availability
        if (!string.IsNullOrWhiteSpace(availability))
        {
            if (availability == "available")
            {
                eventsQuery = eventsQuery.Where(e => e.AvailableTickets > 0);
            }
            else if (availability == "soldout")
            {
                eventsQuery = eventsQuery.Where(e => e.AvailableTickets == 0);
            }
        }

        // Sorting
        eventsQuery = sortBy switch
        {
            "title" => eventsQuery.OrderBy(e => e.Title),
            "title_desc" => eventsQuery.OrderByDescending(e => e.Title),
            "date" => eventsQuery.OrderBy(e => e.DateTime),
            "date_desc" => eventsQuery.OrderByDescending(e => e.DateTime),
            "price" => eventsQuery.OrderBy(e => e.TicketPrice),
            "price_desc" => eventsQuery.OrderByDescending(e => e.TicketPrice),
            _ => eventsQuery.OrderBy(e => e.DateTime)
        };

        // Pass filter values to view
        ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", categoryId);
        ViewBag.SelectedCategory = categoryId;
        ViewBag.SearchTerm = searchTerm;
        ViewBag.SortBy = sortBy;
        ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
        ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
        ViewBag.Availability = availability;

        return View(await eventsQuery.ToListAsync());
    }

    // GET: Events/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var eventItem = await _context.Events
            .Include(e => e.Category)
            .FirstOrDefaultAsync(m => m.EventId == id);

        if (eventItem == null)
        {
            return NotFound();
        }

        return View(eventItem);
    }

    // GET: Events/Create
    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
        return View();
    }

    // POST: Events/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EventId,Title,DateTime,TicketPrice,AvailableTickets,CategoryId")] Event eventItem)
    {
        // Remove the Category navigation property from ModelState to prevent validation errors
        ModelState.Remove("Category");

        if (ModelState.IsValid)
        {
            // Convert DateTime to UTC for PostgreSQL
            if (eventItem.DateTime.Kind == DateTimeKind.Unspecified)
            {
                eventItem.DateTime = DateTime.SpecifyKind(eventItem.DateTime, DateTimeKind.Utc);
            }
            else if (eventItem.DateTime.Kind == DateTimeKind.Local)
            {
                eventItem.DateTime = eventItem.DateTime.ToUniversalTime();
            }

            _context.Add(eventItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", eventItem.CategoryId);
        return View(eventItem);
    }

    // GET: Events/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null)
        {
            return NotFound();
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", eventItem.CategoryId);
        return View(eventItem);
    }

    // POST: Events/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EventId,Title,DateTime,TicketPrice,AvailableTickets,CategoryId")] Event eventItem)
    {
        if (id != eventItem.EventId)
        {
            return NotFound();
        }

        // Remove the Category navigation property from ModelState to prevent validation errors
        ModelState.Remove("Category");

        if (ModelState.IsValid)
        {
            try
            {
                // Convert DateTime to UTC for PostgreSQL
                if (eventItem.DateTime.Kind == DateTimeKind.Unspecified)
                {
                    eventItem.DateTime = DateTime.SpecifyKind(eventItem.DateTime, DateTimeKind.Utc);
                }
                else if (eventItem.DateTime.Kind == DateTimeKind.Local)
                {
                    eventItem.DateTime = eventItem.DateTime.ToUniversalTime();
                }

                _context.Update(eventItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(eventItem.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", eventItem.CategoryId);
        return View(eventItem);
    }

    // GET: Events/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var eventItem = await _context.Events
            .Include(e => e.Category)
            .FirstOrDefaultAsync(m => m.EventId == id);
        if (eventItem == null)
        {
            return NotFound();
        }

        return View(eventItem);
    }

    // POST: Events/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem != null)
        {
            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.EventId == id);
    }
}