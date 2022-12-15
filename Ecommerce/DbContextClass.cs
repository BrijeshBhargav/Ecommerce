using Microsoft.EntityFrameworkCore;

using Ecommerce.Models;


namespace Ecommerce
{
    public class DbContextClass : DbContext
    {
        public DbContextClass()
        {

        }
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {

        }
        public virtual DbSet<Products> product { get; set; }
    }
}
