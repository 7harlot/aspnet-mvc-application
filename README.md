# Virtual Event Ticketing System

## COMP 2139 - Assignment 1

A comprehensive virtual event ticketing system built with ASP.NET Core MVC, enabling users to manage events, browse and purchase tickets, and track guest check-ins.

## Features Implemented

### Core Requirements

1. **Event Management**
   - Create, Read, Update, Delete (CRUD) operations for events
   - Event fields: Title, Category, Date/Time, Ticket Price, Available Tickets
   - Category filtering and management

2. **Event Overview Dashboard**
   - Total events and categories count
   - Low ticket availability alerts (< 5 tickets)
   - Sold-out events tracking
   - Upcoming events list

3. **Search and Filtering**
   - Search by event title or date
   - Filter by:
     - Category (Webinar, Concert, Workshop, Conference)
     - Date range
     - Ticket availability (Available, Sold Out)
   - Sort by:
     - Title (A-Z, Z-A)
     - Date (Ascending, Descending)
     - Price (Low-High, High-Low)

4. **Guest Ticket Purchasing**
   - Browse available events
   - Select events and specify quantity
   - Guest information capture (Name, Email)
   - Purchase confirmation page with summary
   - Automatic ticket inventory management
   - No authentication required

5. **UI/UX Design**
   - Responsive Bootstrap 5 design
   - Modern, event-themed interface with vibrant colors
   - Navigation bar with links to all major features
   - Footer with team information
   - Card-based layouts with hover effects
   - Gradient backgrounds and animations

## Technology Stack

- **Framework**: ASP.NET Core MVC (.NET 8.0)
- **Language**: C#
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **UI Framework**: Bootstrap 5
- **Frontend**: HTML5, CSS3, JavaScript

## Database Schema

### Tables

1. **Categories**
   - CategoryId (PK)
   - Name
   - Description

2. **Events**
   - EventId (PK)
   - Title
   - DateTime
   - TicketPrice
   - AvailableTickets
   - CategoryId (FK)

3. **Purchases**
   - PurchaseId (PK)
   - PurchaseDate
   - TotalCost
   - GuestName
   - GuestEmail

4. **PurchaseItems**
   - PurchaseItemId (PK)
   - PurchaseId (FK)
   - EventId (FK)
   - Quantity
   - PricePerTicket

### Relationships
- One-to-Many: Category → Events
- Many-to-Many: Purchases ↔ Events (via PurchaseItems)

## Setup Instructions

### Prerequisites
1. .NET 8.0 SDK
2. PostgreSQL database server
3. Your favorite IDE (Visual Studio, VS Code, Rider)

### Database Setup

1. **Update connection string** in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=VirtualEventTicketing;Username=postgres;Password=YOUR_PASSWORD"
     }
   }
   ```

2. **Apply migrations**:
   ```bash
   dotnet ef database update
   ```

   This will:
   - Create the database
   - Create all tables
   - Seed initial data (categories and sample events)

### Running the Application

1. **Build the project**:
   ```bash
   dotnet build
   ```

2. **Run the application**:
   ```bash
   dotnet run
   ```

3. **Navigate to**: `https://localhost:5001` or `http://localhost:5000`

## Project Structure

```
assignment-1/
├── Controllers/
│   ├── HomeController.cs
│   ├── EventsController.cs
│   ├── DashboardController.cs
│   └── PurchasesController.cs
├── Models/
│   ├── Category.cs
│   ├── Event.cs
│   ├── Purchase.cs
│   ├── PurchaseItem.cs
│   └── ErrorViewModel.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Events/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   └── Details.cshtml
│   ├── Dashboard/
│   │   └── Index.cshtml
│   ├── Purchases/
│   │   ├── SelectEvent.cshtml
│   │   ├── Create.cshtml
│   │   └── Confirmation.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── Error.cshtml
├── Data/
│   └── ApplicationDbContext.cs
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   └── js/
│       └── site.js
└── Migrations/
    └── [EF Core Migrations]
```

## Features by Page

### Home Page (/)
- Welcome message
- Quick navigation cards to main features
- Category showcase
- Call-to-action buttons

### Events (/Events)
- Comprehensive event list with cards
- Advanced search and filtering
- Create new events
- Edit/Delete existing events

### Dashboard (/Dashboard)
- System statistics
- Low ticket alerts
- Sold-out events list
- Upcoming events

### Buy Tickets (/Purchases/SelectEvent)
- Browse available events
- Quick ticket purchase

### Purchase Form (/Purchases/Create)
- Select quantity
- Enter guest information
- Real-time total calculation

### Confirmation (/Purchases/Confirmation)
- Purchase summary
- Event details
- Confirmation number

## Seed Data

The application includes pre-seeded data:

**Categories:**
- Webinar
- Concert
- Workshop
- Conference

**Sample Events:**
- 8 events across all categories
- Various ticket prices and availability
- Some with low/sold-out status for testing

## MVC Architecture

The application follows proper MVC design principles:

**Models**: Data entities with validation attributes
**Views**: Razor views with Bootstrap styling
**Controllers**: Business logic and route handling
**Data**: DbContext for database operations

## Future Enhancements (Assignment 2)

- User authentication and authorization
- User profiles and purchase history
- Live streaming integration
- Attendee analytics
- Payment gateway integration
- Email confirmations
- QR code tickets
- Event check-in system

## Team Information

**Group**: [Your Group Number]
**Members**: [Your Names]
**Course**: COMP 2139
**Assignment**: Assignment 1
**Due Date**: Friday, October 10th, 2025

## Notes

- No user authentication is required for this assignment (deferred to Assignment 2)
- All purchases are stored with guest information only
- Database uses PostgreSQL but can be adapted to other providers
- Fully responsive design works on mobile, tablet, and desktop

## Troubleshooting

### Database Connection Issues
- Ensure PostgreSQL is running
- Verify connection string credentials
- Check if database exists

### Migration Issues
```bash
# Remove migrations
dotnet ef migrations remove

# Create new migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### Port Conflicts
- Check `Properties/launchSettings.json`
- Modify ports if needed
