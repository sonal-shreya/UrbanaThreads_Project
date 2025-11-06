# Urbana Threads — Retail Inventory & Analytics Dashboard

A modern retail management system built using **ASP.NET MVC**, **Entity Framework**, **Azure SQL**, **Bootstrap**, **Chart.js**, and an **AI assistant chatbot**.

---
## Links

- **Deployed Application:** [Visit Website](https://urbanathreads-fsgadcbtarfth0gk.norwayeast-01.azurewebsites.net/)
- **YouTube Walkthrough:** [Watch the Demo](https://youtu.be/V5Ura06fxM8) In case the deployed application crashes due to lack of credits or free tier. Backup screen recording of our application is available on youtube for reference.

##  Features

### Product & Inventory
- Add, Edit, Delete
- Real-time inventory updates

### Dashboard
- Inventory charts  
- Sales charts  
- Low-stock alerts  

### Orders
- Order & order-item tracking

### AI Assistant
- Botpress-powered retail chatbot

### Azure Cloud
- Azure App Service + Azure SQL deployment

### Security
- Managed Identity authentication

---

##  Architecture

### Frontend
- Razor Views  
- Bootstrap 5  
- JavaScript  
- Chart.js  

### Backend
- ASP.NET MVC (C#)  
- Entity Framework Core  

### Database
- Azure SQL  

### Deployment
- Azure App Service  

### Bot
- Botpress Web Chat  

---

##  ERD Diagram
![ER Diagram](./UrbanaThreadsProject/wwwroot/assets/ERDiagramAppdev.png)


### Tables

| Table      | Key Columns |
|------------|-------------|
| Category   | category_id, name |
| Product    | product_id, name, price, category_id |
| Inventory  | product_id (PK), stock_quantity, reorder_level |
| Orders     | order_id, customer_name, order_date, status |
| OrderItem  | order_item_id, order_id, product_id, qty, unit_price |

---

## API Endpoints

| Endpoint | Purpose |
|---|---|
| `/Dashboard/InventoryDistribution` | Inventory by category (Pie) |
| `/Dashboard/StockByProduct` | Stock by product (Bar) |
| `/Dashboard/InventoryValue` | Total inventory value |
| `/Dashboard/LowStockProducts` | Reorder alert list |
| `/Dashboard/MonthlySales` | Orders grouped by month |
| `/Dashboard/TopProducts` | Most sold items |

---

##  CRUD Overview

| Entity | Operations |
|---|---|
| Products | Create, View, Edit, Delete |
| Inventory | Auto-create, update, reorder alerts |
| Orders | Add order with items, track totals |
| Users | Admin only (future feature) |

---

## Technical Challenges & Solutions

| Challenge | Solution |
|---|---|
| Azure cold start queries slow | Added `.AsNoTracking()` & optimized joins |
| DB access error with EF | Enabled Managed Identity |
| Charts not loading | Converted queries to JSON API + JS fetch |
| Bot layout conflict | Loaded bot only on `Bot.cshtml` via `@section scripts` |
| Azure SQL firewall issues | Enabled trusted services & IP access |

---

##  Installation

```bash
git clone <repo>
cd UrbanaThreads
update appsettings.json


---

##  AI Assistant Integration

- Botpress WebChat scripts included  
- AI Assistant page for retail Q&A  
- Trained for:
  - Product lookup  
  - Sales help  
  - Reorder guidance  

---

##  Team Members & Responsibilities

### **Sumit Kumar Singh — Frontend & Analytics**
- Chart.js dashboards, UI branding  
- Navigation & scripts  
- Chatbot workflow  

### **Sonal Shreya — Full Stack & Data Engineer**
- Project setup & DB schema  
- Home page UI  
- Azure deployment & chatbot integration  

### **Aishwarya Gopal — Full Stack Developer**
- About page  
- Add & Edit inventory features  
- Chatbot contribution  

### **Simran Anjana Rajput — UI & Backend**
- UI theme & styles  
- View/Delete modules  
- Chatbot contribution  

---

##  Future Enhancements
- Role-based auth  
- Export reports to Excel/PDF  
- Real-time stock notifications  
- Payment & delivery module  
- Admin dashboard improvements  

---

##  Deployment Summary
- Azure App Service (Free Tier)  
- Azure SQL (Free Tier)  
- Managed Identity authentication  
- Temporary monitoring enabled  

---

dotnet ef database update
dotnet run
