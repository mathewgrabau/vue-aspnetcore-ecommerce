using System.Threading.Tasks;
using FirstProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Features.Products
{
	[Route("api/[controller]")]
	public class ProductsController : Controller
	{
		private readonly FirstProjectContext _db;

		public ProductsController(FirstProjectContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IActionResult> Find()
		{
			var products = await _db.Products.ToListAsync();
			return Ok(products);
		}

		[HttpGet("{slug}")]
		public async Task<IActionResult> Get(string slug)
		{
			var product = await _db.Products.SingleOrDefaultAsync(x => x.Slug == slug);

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}
	}
}