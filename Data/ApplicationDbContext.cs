using Microsoft.EntityFrameworkCore;
using SRVIndia.Models;

namespace SRVIndia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensures the table name is exactly 'contactus' in MySQL
            modelBuilder.Entity<ContactUs>().ToTable("contactus");
        }
    }
}