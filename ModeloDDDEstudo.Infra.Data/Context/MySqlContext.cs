using Microsoft.EntityFrameworkCore;
using ModeloDDDEstudo.Domain.Entities;
using ModeloDDDEstudo.Infra.Data.Mapping;

namespace ModeloDDDEstudo.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=Modelo;Uid=root;Pwd=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
