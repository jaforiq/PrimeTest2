using Microsoft.EntityFrameworkCore;
using PrimeTest2.Models;

namespace PrimeTest2.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Invoice> invoices { get; set; }
    }
}
