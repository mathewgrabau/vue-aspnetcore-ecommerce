using System.Collections.Generic;
using System.Linq;
using FirstProject.Data;
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

			AddProducts(context);
		}

		private static void AddProducts(FirstProjectContext context)
		{
			if (context.Products.Any() == false)
			{
				var products = new List<Product>
				{
				new Product {
					Name = "Samsung Galaxy S8",
					Slug= "samsung-galaxy-s8",
					Thumbnail= "http://placehold.it/200x300",
					ShortDescription=
							"Samsung Galaxy S8 Android smartphone with  true edge to edge display",
					Price= 499.99M,
					Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
				},
				new Product {
					Name= "Samsung Galaxy S7",
					Slug= "samsung-galaxy-s7",
					Thumbnail= "http://placehold.it/200x300",
					ShortDescription=
							"Samsung Galaxy S8 Android smartphone with  true edge to edge display",
					Price= 499.99M,
					Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
				},
				new Product {
					Name= "Samsung Galaxy S6",
					Slug= "samsung-galaxy-s6",
					Thumbnail= "http://placehold.it/200x300",
					ShortDescription=
							"Samsung Galaxy S8 Android smartphone with  true edge to edge display",
					Price= 499.99M,
					Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
				},
				new Product {
					Name= "Samsung Galaxy S5",
					Slug= "samsung-galaxy-s5",
					Thumbnail= "http://placehold.it/200x300",
					ShortDescription=
							"Samsung Galaxy S8 Android smartphone with  true edge to edge display",
					Price= 499.99M,
					Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
				},
				new Product {
					Name = "Samsung Galaxy S4",
					Slug= "samsung-galaxy-s4",
					Thumbnail= "http://placehold.it/200x300",
					ShortDescription=                           "Samsung Galaxy S8 Android smartphone with  true edge to edge display",
					Price= 499.99M,
					Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
				}};


				// Add them in
				context.Products.AddRange(products);
				context.SaveChanges();
			}
		}
	}
}
