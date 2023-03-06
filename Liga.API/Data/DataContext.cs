using Liga.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Liga.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hero> Heroes => Set<Hero>();

        public DbSet<Weakness> Weaknesses => Set<Weakness>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Para tomar los calores de ConfigEntities
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //De esta manera podemos crear un regla general para un tipo de Dato
            //sera automatico.
            //configurationBuilder.Properties<string>().HaveMaxLength(50);
        }

    }
}
