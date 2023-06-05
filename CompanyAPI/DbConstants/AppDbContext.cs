using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.DbConstants
{
    public class AppDbContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost; Port=5432; Database=Company-db; User Id=postgres; Password=2001;";
            optionsBuilder.UseNpgsql(connectionString);
        }


    }
}
