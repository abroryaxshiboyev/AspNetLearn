using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole{
            Id = "1b223b77-1a69-4fcd-8b30-2145bd3745a1", // Statik GUID
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole{
            Id = "2d77a3a5-2c7b-4de8-9a44-517d2f1a4d2b", // Statik GUID
            Name = "User",
            NormalizedName = "USER"
        },
    };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}