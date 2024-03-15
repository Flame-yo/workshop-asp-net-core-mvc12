using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc12.Models;

namespace SalesWebMvc12.Data
{
    public class SalesWebMvc12Context : DbContext
    {
        public SalesWebMvc12Context (DbContextOptions<SalesWebMvc12Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
