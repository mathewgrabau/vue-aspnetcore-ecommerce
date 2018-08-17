using FirstProject.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Data
{
	public class FirstProjectContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public FirstProjectContext(DbContextOptions<FirstProjectContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Product>()
				.HasIndex(b => b.Slug)
				.IsUnique();
		}
	}
}