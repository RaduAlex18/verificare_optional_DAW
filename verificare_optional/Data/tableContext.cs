using Microsoft.EntityFrameworkCore;
using verificare_optional.Models;

namespace verificare_optional.Data
{
    public class tableContext:DbContext
    {

        public tableContext() { }

        public DbSet<Autori> Autoris { get; set; }
        public DbSet<Carti>Cartis { get; set; }
        public DbSet<Editura>Edituras { get; set; }
        public DbSet<ModelsRelationAUCT> ModelsRelationsAUCT { get; set; }

        public tableContext(DbContextOptions<tableContext> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=verificare_optional;TrustServerCertificate=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-Many Editura-Autori
            modelBuilder.Entity<Editura>()
                        .HasMany(au => au.Autorii)
                        .WithOne(e => e.Editura);

            //Many-to-many Autori-Carti
            modelBuilder.Entity<ModelsRelationAUCT>().HasKey(mrAUCT => new { mrAUCT.AutorId, mrAUCT.CarteId });

            //one-to-many for many-to-many
            modelBuilder.Entity<ModelsRelationAUCT>()
                       .HasOne(mrAUCT => mrAUCT.Autori)
                       .WithMany(au => au.ModelsRelationsAUCT)
                       .HasForeignKey(mrAUCT => mrAUCT.AutorId);

            modelBuilder.Entity<ModelsRelationAUCT>()
                        .HasOne(mrAUCT => mrAUCT.Carti)
                        .WithMany(ct => ct.ModelsRelationsAUCT)
                        .HasForeignKey(mrAUCT => mrAUCT.CarteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
