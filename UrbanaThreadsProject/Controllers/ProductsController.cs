using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrbanaThreadsProject.Data;
using UrbanaThreadsProject.Models;

namespace UrbanaThreadsProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ LIST
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .ToListAsync();

            return View("~/Views/Products/read.cshtml", products);
        }

        // CREATE FORM
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            return View("~/Views/Products/create.cshtml");
        }

        // CREATE SUBMIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, int StockQuantity, int ReorderLevel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
                return View("~/Views/Products/create.cshtml", product);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var inventory = new Inventory
            {
                ProductId = product.ProductId,
                StockQuantity = StockQuantity,
                ReorderLevel = ReorderLevel,
                LastRestocked = DateTime.Now
            };

            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            TempData["Success"] = " Product added successfully!";
            return RedirectToAction(nameof(Index));
        }

        // EDIT FORM
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View("~/Views/Products/update.cshtml", product);
        }

        // EDIT SUBMIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, int StockQuantity, int ReorderLevel)
        {
            var existing = await _context.Products.Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.SKU = product.SKU;
            existing.CategoryId = product.CategoryId;
            existing.ImageUrl = product.ImageUrl;

            if (existing.Inventory == null)
            {
                existing.Inventory = new Inventory
                {
                    ProductId = existing.ProductId,
                    StockQuantity = StockQuantity,
                    ReorderLevel = ReorderLevel,
                    LastRestocked = DateTime.Now
                };
            }
            else
            {
                existing.Inventory.StockQuantity = StockQuantity;
                existing.Inventory.ReorderLevel = ReorderLevel;
                existing.Inventory.LastRestocked = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = " Product updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // DELETE VIEW
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Include(p => p.Category)
                .Include(p => p.Inventory).FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return NotFound();

            return View("~/Views/Products/delete.cshtml", product);
        }

        // DELETE CONFIRM
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.ProductId == id);
                if (inventory != null) _context.Inventory.Remove(inventory);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = " Product deleted!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
