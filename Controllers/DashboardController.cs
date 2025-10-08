using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment_1.Data;
using assignment_1.Models;

namespace assignment_1.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel
        {
            TotalEvents = await _context.Events.CountAsync(),
            TotalCategories = await _context.Categories.CountAsync(),
            LowTicketEvents = await _context.Events
                .Include(e => e.Category)
                .Where(e => e.AvailableTickets > 0 && e.AvailableTickets < 5)
                .ToListAsync(),
            SoldOutEvents = await _context.Events
                .Include(e => e.Category)
                .Where(e => e.AvailableTickets == 0)
                .ToListAsync(),
            UpcomingEvents = await _context.Events
                .Include(e => e.Category)
                .Where(e => e.DateTime > DateTime.Now)
                .OrderBy(e => e.DateTime)
                .Take(5)
                .ToListAsync()
        };

        return View(viewModel);
    }
}