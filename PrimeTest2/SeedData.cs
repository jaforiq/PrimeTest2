using Microsoft.EntityFrameworkCore;
using PrimeTest2.Data;
using PrimeTest2.Models;

namespace PrimeTest2;

public class SeedData
{
	public static void SeedDatabase(ApplicationDbContext context)
	{
		context.Database.Migrate();
		if (!context.products.Any())
		{
			context.products.AddRange(
			new Product
			{
				Name = "Tshirt",
				ProductCode = "007",
				Description = "Mans Shirt",
				Prize = 100.00
			},
			new Product
			{
				Name = "Tshirt",
				ProductCode = "008",
				Description = "Ladis Shirt",
				Prize = 200.00
			},
			new Product
			{
				Name = "Salwar",
				ProductCode = "009",
				Description = "Ladis Cloth",
				Prize = 500.00
			},
			new Product
			{
				Name = "Jeans",
				ProductCode = "010",
				Description = "Mans Cloth",
				Prize = 600.00
			},
			new Product
			{
				Name = "Skirt",
				ProductCode = "011",
				Description = "Ladies Cloth",
				Prize = 300.00
			}
			);
			context.SaveChanges();
		}
	}
}
