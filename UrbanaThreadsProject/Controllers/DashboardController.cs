using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanaThreadsProject.Data;

namespace UrbanaThreadsProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Data.cshtml");
        }

        // ✅ Sales Value (Price × Stock)
        [HttpGet]
        public async Task<IActionResult> SalesByCategory(string category = "all")
        {
            var query = _context.Products
                .Include(p => p.Inventory)
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "all")
                query = query.Where(p => p.Category.Name == category);

            var data = await query
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    Value = g.Sum(p => p.Price * (p.Inventory.StockQuantity))
                })
                .ToListAsync();

            return Json(data);
        }

        // ✅ Inventory Distribution
        [HttpGet]
        public async Task<IActionResult> InventoryDistribution()
        {
            var data = await _context.Products
                .Include(p => p.Inventory)
                .Include(p => p.Category)
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    Stock = g.Sum(p => p.Inventory.StockQuantity)
                })
                .ToListAsync();

            return Json(data);
        }

        // ✅ Low Stock List
        [HttpGet]
        public async Task<IActionResult> LowStockProducts()
        {
            var lowStock = await _context.Products
                .Include(p => p.Inventory)
                .Where(p => (p.Inventory.StockQuantity) <= (p.Inventory.ReorderLevel))
                .Select(p => new
                {
                    p.Name,
                    Stock = p.Inventory.StockQuantity,
                    ReorderLevel = p.Inventory.ReorderLevel
                })
                .ToListAsync();

            return Json(lowStock);
        }

        //  Category Dropdown
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                .Select(c => c.Name)
                .ToListAsync();

            return Json(categories);
        }

        // Stock by Product chart
        [HttpGet]
        public async Task<IActionResult> StockByProduct(string category = "all")
        {
            var query = _context.Products
                .Include(p => p.Inventory)
                .Include(p => p.Category)
                .AsQueryable();

            if (category != "all")
                query = query.Where(p => p.Category.Name == category);

            var data = await query
                .Select(p => new {
                    name = p.Name,
                    stock = p.Inventory.StockQuantity
                })
                .ToListAsync();

            return Json(data);
        }

        // ✅ Monthly Sales Trend
        [HttpGet]
        public async Task<IActionResult> MonthlySalesTrend()
        {
            var data = await _context.Orders
                .Where(o => o.Status == "Completed")
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Month = g.Key.Year + "-" + g.Key.Month,
                    Total = g.Sum(o => o.TotalAmount)
                })
                .OrderBy(x => x.Month)
                .ToListAsync();

            return Json(data);
        }

        // ✅ Top Selling Products
        [HttpGet]
        public async Task<IActionResult> TopSellingProducts()
        {
            var data = await _context.OrderItems
                .Include(oi => oi.Product)
                .GroupBy(oi => oi.Product.Name)
                .Select(g => new
                {
                    Product = g.Key,
                    Quantity = g.Sum(i => i.Quantity)
                })
                .OrderByDescending(x => x.Quantity)
                .Take(5)
                .ToListAsync();

            return Json(data);
        }

    }
}
