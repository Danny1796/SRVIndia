using Microsoft.EntityFrameworkCore;
using SRVIndia.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Enquiries> Enquiries { get; set; }
    public DbSet<MainBanners> MainBanners { get; set; }
    public DbSet<Distributor> Distributors { get; set; }
}