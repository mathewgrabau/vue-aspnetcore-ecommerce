using FirstProject.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FirstProject.Data
{
	public static class DbContextExtensions
	{
		public static UserManager<AppUser> UserManager { get; set; }

		public static void EnsureSeeded(this FirstProjectContext context)
		{
			if (UserManager.FindByEmailAsync("mgrabau@mathewgrabau.ca").GetAwaiter().GetResult() == null)
			{
				var user = new AppUser
				{
					FirstName = "Mathew",
					LastName = "Grabau",
					UserName = "mgrabau@mathewgrabau.ca",
					Email = "mgrabau@mathewgrabau.ca",
					EmailConfirmed = true,
					LockoutEnabled = false
				};

				UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
			}
		}
	}

}