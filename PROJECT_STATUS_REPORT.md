# COMP 2139 - Assignment 1
## Project Status Report

**Group Number:** [61]
**Team Members:** [Ben Morrison]
**Date:** [10.08.2025]
**Project:** Virtual Event Ticketing System

---

## ✅ Completed Requirements

### 1. Event Management
- ✅ **Event Listing Page** - Displays all events with category filtering
- ✅ **Create Event Form** - Complete with all required fields (Title, Category, Date/Time, Price, Available Tickets)
- ✅ **Update Event** - Edit functionality for existing events
- ✅ **Delete Event** - Remove events with confirmation dialog
- ✅ **Event Overview Dashboard** - Shows total events, categories, and low ticket alerts (< 5 tickets)

### 2. Search and Filtering
- ✅ **Search Functionality** - Real-time search by event title or date
- ✅ **Category Filter** - Filter events by category (Webinar, Concert, Workshop, Conference)
- ✅ **Date Range Filter** - Filter by start and end dates
- ✅ **Availability Filter** - Filter by available or sold-out status
- ✅ **Sorting Options** - Sort by title (A-Z, Z-A), date (ascending/descending), and price (low-high, high-low)

### 3. Guest Ticket Purchasing
- ✅ **Event Selection** - Browse and select available events
- ✅ **Purchase Form** - Specify ticket quantity and guest information (name, email)
- ✅ **Confirmation Page** - Displays purchase summary with event details, purchase date, total cost, and guest contact info
- ✅ **Inventory Management** - Automatic ticket count reduction after purchase
- ✅ **No Authentication Required** - Guest users can purchase without registration

### 4. Application UX and Design
- ✅ **Homepage** - Welcome page with navigation to all key features
- ✅ **Responsive Design** - Bootstrap 5 with mobile-friendly layout
- ✅ **Modern Aesthetics** - Vibrant colors, gradient backgrounds, event-themed graphics
- ✅ **Navigation Bar** - Links to Events, Dashboard, and Ticket Purchasing
- ✅ **Footer** - Team information displayed (group number and member names)

### 5. Database Implementation
- ✅ **Entity Framework Core** - ORM with PostgreSQL provider
- ✅ **Core Tables** - Events, Categories, Purchases, PurchaseItems
- ✅ **Relationships** - One-to-many (Category→Events), Many-to-many (Purchases↔Events via PurchaseItems)
- ✅ **Data Integrity** - Foreign keys, constraints, and validation attributes
- ✅ **Migrations** - Included in version control
- ✅ **Seed Data** - 4 categories and 8 sample events with varied availability
- ✅ **Entity Relationship Diagram** - [Include screenshot or reference to ERD if created]

### 6. MVC Architecture
- ✅ **Models** - Event, Category, Purchase, PurchaseItem with proper data annotations
- ✅ **Views** - Razor views for all CRUD operations and purchasing flow
- ✅ **Controllers** - EventsController, DashboardController, PurchasesController, HomeController
- ✅ **Proper Separation** - Business logic in controllers, presentation in views, data in models

### 7. Technical Requirements
- ✅ **ASP.NET Core MVC** - Framework used throughout
- ✅ **C#** - Primary programming language
- ✅ **PostgreSQL** - Database provider
- ✅ **.NET 8.0** - Target framework
- ✅ **Web Server** - Kestrel (built-in ASP.NET Core server)

---

## ❌ Uncompleted Requirements

### None
All compulsory components for Assignment 1 have been successfully implemented and tested.

---

## 🔄 Known Issues / Limitations

1. **DateTime Display** - All dates stored in UTC; may need timezone conversion for display in different regions
2. **Form Validation** - Client-side validation works, but could be enhanced with custom error messages
3. **No Pagination** - Event list shows all events; pagination would improve performance with large datasets

*Note: These are minor enhancements and do not affect core functionality.*

---

## 🚀 Features Beyond Requirements

### Additional Implementations:
1. **Dynamic Total Calculation** - Real-time cost calculation on purchase form using JavaScript
2. **Visual Status Indicators** - Color-coded cards for low availability and sold-out events
3. **Animations** - Fade-in effects for cards and alerts
4. **Hover Effects** - Interactive card hover states for improved UX
5. **Comprehensive Dashboard** - Includes sold-out events tracking and upcoming events list

---

## 📊 Testing Summary

All features have been thoroughly tested:
- ✅ Event CRUD operations
- ✅ Search and filtering combinations
- ✅ Ticket purchase flow
- ✅ Dashboard statistics and alerts
- ✅ Form validation
- ✅ Database integrity
- ✅ Responsive design on multiple screen sizes

---

## 📝 Notes

- All migrations are included in the repository
- Seed data provides comprehensive test scenarios
- Code follows ASP.NET Core MVC best practices
- Comments added where complex logic is implemented

---

**Submitted By:**
[Ben Morrison]
[61]
COMP 2139 - Assignment 1
[10.08.25]
