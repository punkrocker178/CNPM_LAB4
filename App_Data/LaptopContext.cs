using Lab3_CNPM.Models;
using System;
using System.Data.Entity;

namespace Lab3_CNPM
{
    public class LaptopContext: DbContext
    {
        public LaptopContext() : base()
        {
            
        }
        public DbSet<Laptop> Laptops { get; set; }
    }
}