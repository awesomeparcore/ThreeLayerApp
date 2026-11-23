using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Parameterless constructor so design-time tools (scaffolding, migrations) can create the context
        public ApplicationDbContext()
        { }

        // Used at runtime: options come from AddDbContext in Program.cs
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only runs when no options were supplied (e.g. the scaffolder used the parameterless constructor)
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Dominican;Trusted_connection=true");
            }
        }

        //Employees DbSet for Employees table in SQL
        public DbSet<Employee> Employees { get; set; }

    }
}
