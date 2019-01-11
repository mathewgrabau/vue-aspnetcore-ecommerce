using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstProject.Data;

namespace FirstProject.Features.Filters
{
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        private readonly FirstProjectContext _db;

        public FiltersController(FirstProjectContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _db.Brands.Select(x => x.Name).ToListAsync();

            var storage = await _db.Storage.Select(x => $"{x.Capacity}GB").ToListAsync();

            var colours = await _db.Colours.Select(x => x.Name).ToListAsync();

            var os = await _db.OS.Select(x => x.Name).ToListAsync();

            var features = await _db.Features.Select(x => x.Name).ToListAsync();

            return Ok(new FiltersListViewModel
            {
                Brands = brands,
                Storage = storage,
                Colours = colours,
                OS = os,
                Features = features
            });
        }
    }
}
