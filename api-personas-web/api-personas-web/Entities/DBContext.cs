using api_personas_web.Entities.ModelsSQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> Options) : base(Options) {}

        public DbSet<sp_ActualizarPersonaFisica_Result> sp_ActualizarPersonaFisica { get; set; }
        public DbSet<sp_AgregarPersonaFisica_Result> sp_AgregarPersonaFisica { get; set; }
        public DbSet<sp_EliminarPersonaFisica_Result> sp_EliminarPersonaFisica { get; set; }
        public DbSet<sp_ObtenerPersonaFisica_Resul> sp_ObtenerPersonaFisica { get; set; }

        protected override void OnModelCreating(ModelBuilder Model)
        {
            // modelBuilder.Entity<Sp_tp_SMSAgregar_Result>().Property(e => e.Id).HasConversion(v => v, v => Convert.ToInt32(v));
        }
    }
}
