using Microsoft.EntityFrameworkCore;

namespace verificare_optional.Data
{
    public class tableContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=verificare_optional;TrustServerCertificate=True;");

            }
        }
    }
}
