using BHRUGEN_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BHRUGEN_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
    }
}