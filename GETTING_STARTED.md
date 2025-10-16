# Getting Started - Virtual Event Ticketing System

## 🎉 Your Application is Ready!

Congratulations! Your Virtual Event Ticketing System has been successfully built and is ready to use.

## 🚀 Quick Start

### Application is Currently Running
- **URL**: http://localhost:5088
- **Status**: ✅ Running
- To stop: Press `Ctrl+C` in the terminal

### To Run Again Later
```bash
dotnet run
```

## 📋 What's Been Completed

### ✅ All Core Features Implemented

1. **Event Management** (Full CRUD)
   - Create, Read, Update, Delete events
   - Filter by category
   - Event overview dashboard with alerts

2. **Advanced Search & Filtering**
   - Search by title or date
   - Filter by category, date range, availability
   - Sort by title, date, or price

3. **Guest Ticket Purchasing**
   - Browse available events
   - Purchase tickets without authentication
   - Confirmation page with summary
   - Automatic inventory management

4. **Dashboard**
   - Total events & categories
   - Low ticket alerts (< 5 tickets)
   - Sold-out events tracking
   - Upcoming events list

5. **Modern UI/UX**
   - Responsive Bootstrap 5 design
   - Event-themed with vibrant colors
   - Card layouts with hover effects
   - Gradient backgrounds

## 🗄️ Database

- **Type**: PostgreSQL
- **Name**: VirtualEventTicketing
- **Status**: ✅ Created and Seeded

### Seed Data Included
- **4 Categories**: Webinar, Concert, Workshop, Conference
- **8 Sample Events**: Various prices, dates, and availability
- Ready to test all features immediately!

## 🌐 Navigation

### Main Pages
1. **Home** (http://localhost:5088/)
   - Welcome page with quick navigation

2. **Dashboard** (http://localhost:5088/Dashboard)
   - System overview and statistics

3. **Events** (http://localhost:5088/Events)
   - List, create, edit, delete events
   - Search and filter functionality

4. **Buy Tickets** (http://localhost:5088/Purchases/SelectEvent)
   - Browse and purchase tickets

## 🧪 Testing the Application

### Test Scenarios

#### 1. Browse Events
- Go to Events page
- Try different filters and sort options
- View event details

#### 2. Create a New Event
- Click "Create New Event"
- Fill in the form
- Submit and verify it appears in the list

#### 3. Purchase Tickets
- Go to "Buy Tickets"
- Select an event
- Enter guest information
- Complete purchase
- View confirmation

#### 4. Dashboard Analytics
- Visit Dashboard
- Check low ticket alerts
- View upcoming events

#### 5. Search & Filter
- Search for specific events
- Filter by category
- Try date range filtering
- Test different sort options

## 📁 Project Structure

```
assignment-1/
├── Controllers/        # MVC Controllers
├── Models/            # Data models and view models
├── Views/             # Razor views
├── Data/              # DbContext
├── Migrations/        # EF Core migrations
└── wwwroot/           # Static files (CSS, JS)
```

## 🛠️ Common Commands

### Database
```bash
# View migrations
dotnet ef migrations list

# Update database
dotnet ef database update

# Add new migration
dotnet ef migrations add MigrationName
```

### Build & Run
```bash
# Build
dotnet build

# Run
dotnet run

# Watch (auto-restart on changes)
dotnet watch run
```

## 🎨 Customization

### Update Team Information
Edit `Views/Shared/_Layout.cshtml` (line 54):
```html
<p class="mb-0"><strong>Group:</strong> [Your Group Number] | <strong>Members:</strong> [Your Names]</p>
```

### Change Color Scheme
Edit `wwwroot/css/site.css` to modify:
- Background gradients
- Button colors
- Card styling

## 📝 Assignment Requirements Met

### ✅ Compulsory Components
- [x] ASP.NET Core MVC
- [x] C# (.NET 8.0)
- [x] PostgreSQL Database
- [x] MVC Design Pattern
- [x] Event Management (CRUD)
- [x] Event Overview Dashboard
- [x] Search and Filtering
- [x] Guest Ticket Purchasing
- [x] Responsive UI/UX Design
- [x] Navigation & Footer

### ✅ Database
- [x] Entity Framework Core
- [x] Migrations included in repo
- [x] Seed data
- [x] Proper relationships
- [x] Foreign keys & constraints

### ✅ User Experience
- [x] Homepage with navigation
- [x] Modern, event-themed design
- [x] Responsive layout
- [x] Clear navigation
- [x] Team information in footer

## 📦 Deliverables Ready

You still need to create:

1. **1-Page Project Status Report**
   - List completed requirements
   - List any uncompleted requirements (if any)
   - Explanations for incomplete items

2. **Video Demonstration**
   - Intro slide with team info
   - Demonstrate all features
   - Show code walkthrough
   - Reference status report
   - 5-10 minutes maximum

3. **GitHub Repository**
   - Push code to private GitHub repo
   - Ensure migrations are included
   - Update README with team info

## ⚠️ Before Submission

### Checklist
- [ ] Update team information in footer
- [ ] Update README.md with team details
- [ ] Test all features thoroughly
- [ ] Create 1-page status report
- [ ] Record video demonstration
- [ ] Push to private GitHub repository
- [ ] Submit to Brightspace

## 🐛 Troubleshooting

### Application won't start
- Check if PostgreSQL is running
- Verify connection string in `appsettings.json`
- Ensure database was created: `dotnet ef database update`

### Database errors
- Drop database and recreate:
  ```bash
  dotnet ef database drop
  dotnet ef database update
  ```

### Port conflicts
- Application uses port 5088 by default
- Change in `Properties/launchSettings.json` if needed

## 🎓 Next Steps (Assignment 2)

Features deferred to Assignment 2:
- User authentication & authorization
- User profiles & purchase history
- Live streaming integration
- Attendee analytics
- Payment gateway integration
- Email confirmations
- QR code tickets

## 📧 Support

If you encounter issues:
1. Check this guide
2. Review README.md
3. Check assignment requirements
4. Consult course materials

---

**Good luck with your demonstration and submission! 🚀**

Remember to:
- Test thoroughly before recording
- Highlight the search/filter features
- Show the purchase flow
- Demonstrate the dashboard
- Update your team information!
