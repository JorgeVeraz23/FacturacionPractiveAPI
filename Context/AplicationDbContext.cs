using backend_tareas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tareas.Context

{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
            public DbSet<Tarea> Tareas { get; set; }
            public DbSet<FacturaCabecera> FacturaCabeceras { get; set; }
            public DbSet<FacturaDetalle> FacturaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FacturaCabecera>().
                HasMany(f => f.FacturaDetalles)
                .WithOne(d => d.FacturaCabecera)
                .HasForeignKey(d => d.IdFacturaCabecera);

            base.OnModelCreating(modelBuilder);
        }
    }
}
