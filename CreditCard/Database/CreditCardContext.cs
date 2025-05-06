using CreditCardApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Database
{
    public class CreditCardContext : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Order> Orders { get; set; }

        public CreditCardContext(DbContextOptions<CreditCardContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
