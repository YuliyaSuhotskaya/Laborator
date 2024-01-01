using Laborator.Entities;
using Laborator.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laborator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }

       public DbSet<Jewelry> Jewelries { get; set; }
       public DbSet<JewelryGroup> JewelryGroups { get; set; }

    }
}


