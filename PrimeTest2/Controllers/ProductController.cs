using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeTest2.Data;

namespace PrimeTest2.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public ProductController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var product = await _applicationDbContext.products.ToListAsync();
			return View(product);
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var product = await _applicationDbContext.products.FindAsync(id);
			return View(product);
		}
	}
}
