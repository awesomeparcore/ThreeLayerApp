using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.Data
{
    // Used only by design-time tools (Visual Studio scaffolding, EF migrations)
    // so they can create ApplicationDbContext without running Program.cs.
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Dominican;Trusted_connection=true");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
