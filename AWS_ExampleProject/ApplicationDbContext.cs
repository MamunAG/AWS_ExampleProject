using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //seed
        //builder.ApplyConfiguration(new CountryConfiguration());
        //builder.ApplyConfiguration(new HotelConfiguration());
        //builder.ApplyConfiguration(new RoleConfiguration());
        //end seed
    }

    //public DbSet<Hotel> Hotels { get; set; }
}