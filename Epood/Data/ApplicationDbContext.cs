using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Epood.Models;

namespace Epood.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Epood.Models.Booking> Bookings { get; set; } = default!;

        public DbSet<Epood.Models.Customer> Customers { get; set; } = default!;

        public DbSet<Epood.Models.Invoice> Invoices { get; set; } = default!;

        public DbSet<Epood.Models.Product> Products { get; set; } = default!;

        public DbSet<Epood.Models.ProductType> ProductTypes { get; set; } = default!;
    }
}
