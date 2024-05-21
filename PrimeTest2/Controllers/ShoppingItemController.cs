using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeTest2.Data;
using PrimeTest2.Models;
using PrimeTest2.Session;

namespace PrimeTest2.Controllers
{
    public class ShoppingItemController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ShoppingItemController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> AddToCart(Guid id)
        {
            var product = await _applicationDbContext.products.FindAsync(id);
            var shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>("Cart") ?? new List<ShoppingItem>();

            var existingItem = shoppingItems.FirstOrDefault(item => item.Product.Id == id);

            if(existingItem != null)
            {
                existingItem.Quantity++;

            }
            else
            {
                shoppingItems.Add(new ShoppingItem
                {
                    Product = product,
                    Quantity = 1
                });
            }

            HttpContext.Session.Set("Cart", shoppingItems);
            return RedirectToAction("List", "Product");
        }

        
        public IActionResult ViewShopping()
        {
            var shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>("Cart") ?? new List<ShoppingItem>();
            var shoppingView = new ShoppingItemViewModel
            {
                Items = shoppingItems,
                TotalPrice = shoppingItems.Sum(item => item.Product.Prize * item.Quantity)
            };

            return View(shoppingView);
        }

        
        public IActionResult ViewInvoice()
        {
            var shoppingItems = HttpContext.Session.Get<List<ShoppingItem>>("Cart") ?? new List<ShoppingItem>();
            foreach(var item in  shoppingItems)
            {
                _applicationDbContext.Add(new Invoice
                {
                    ProductId = item.Product.Id,
                    Quentity = item.Quantity,
                    PurchesDate = DateTime.Now,
                    Total = item.Product.Prize * item.Quantity
                });  
            }
            _applicationDbContext.SaveChanges();

            HttpContext.Session.Set("Cart", new List<ShoppingItem>());
            
            return View("ViewInvoice");
        }

        [HttpGet]
        public async Task<IActionResult> AllPurches()
        {
            var allParches = await _applicationDbContext.invoices.ToListAsync();
            return View(allParches);
        }
    }
}
