using Aplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public class AppicationContext : DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }

        public DbSet<Movimento> Movimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Checkouts\Desafio\teste\Application\bd\Application.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(prop => prop.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
