using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        [HttpGet]
        public async Task<IActionResult> Find(string brands, int? minPrice, int? maxPrice, int? minScreen, int? maxScreen, string capacity, string colours, string os, string features)
        {
            var brandList = string.IsNullOrEmpty(brands) ? new List<string>() : brands.Split('|').ToList();
            var capacityListTemp = string.IsNullOrEmpty(capacity) ? new List<string>() : capacity.Split('|').ToList();
			var capacityList = new List<int>();
			var numberRegex = new Regex(@"(\d+)", RegexOptions.Compiled);
            // Process and ensure that we just have the capacity value for the numeral available
            for (int i = 0; i < capacityListTemp.Count; ++i)
            {
				var matches = numberRegex.Matches(capacityListTemp[i]);
				if (matches.Count == 1)
				{
					capacityList[i] = int.Parse(matches[0].Groups[0].Value);
				}
            }
            var colourList = string.IsNullOrEmpty(colours) ? new List<string>() : colours.Split('|').ToList();
            var osList = string.IsNullOrEmpty(os) ? new List<string>() : os.Split('|').ToList();
            var featureList = string.IsNullOrEmpty(features) ? new List<string>() : features.Split('|').ToList();

            var products = await _db.Products
                .Where(x => !brandList.Any() || brandList.Contains(x.Brand.Name))
                .Where(x => !minPrice.HasValue || x.ProductVariants.Any(v => v.Price >= minPrice.Value))
                .Where(x => !maxPrice.HasValue || x.ProductVariants.Any(v => v.Price <= maxPrice.Value))
                .Where(x => !minScreen.HasValue || x.ScreenSize >= Convert.ToDecimal(minScreen.Value))
                .Where(x => !maxScreen.HasValue || x.ScreenSize >= Convert.ToDecimal(maxScreen.Value))
                .Where(x => !capacityList.Any() || x.ProductVariants.Any(v => capacityList.Contains(v.Storage.Capacity)))
                .Where(x => !colourList.Any() || x.ProductVariants.Any(v => colourList.Contains(v.Colour.Name)))
                .Where(x => !osList.Any() || osList.Contains(x.OS.Name))
                .Where(x => !featureList.Any() || featureList.All(f => x.ProductFeatures.Any(pf => pf.Feature.Name == f)))
                .Select(x => new ProductListViewModel
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    Thumbnail = x.Thumbnail,
                    Price = x.ProductVariants.OrderBy(v => v.Price).First().Price
                }).ToListAsync();

            return Ok(products);
        }
    }
}