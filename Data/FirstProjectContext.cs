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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Storage> Storage { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            // Configure the relationships
            builder.Entity<ProductFeature>()
                .HasKey(pf => new { pf.ProductId, pf.FeatureId });

            builder.Entity<ProductVariant>()
                .HasKey(pv => new { pv.ProductId, pv.ColourId, pv.StorageId });
        }
    }
}