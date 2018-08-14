using System.Threading.Tasks;
using FirstProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Features.Users
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly FirstProjectContext _db;

		public UsersController(FirstProjectContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _db.Users.ToListAsync());
		}
	}
}