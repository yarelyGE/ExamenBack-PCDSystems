using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace examenBack.Controllers.Data
{
    public class WebinarDBContext(DbContextOptions<WebinarDBContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
