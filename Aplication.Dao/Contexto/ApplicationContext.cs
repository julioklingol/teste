using Aplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        public DbSet<Movimento> Movimentos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(prop => prop.Entity.GetType().GetProperty("DataHora") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHora").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHora").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
