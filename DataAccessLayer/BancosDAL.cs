using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BancosMDacosta.DataAccessLayer {
    public class BancosDAL : DbContext {
        public DbSet<BancoUsers> BancoUsers { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Entidades> Entidades { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<TiposCuenta> TiposCuenta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<BancoUsers>().ToTable("BancoUsers");
            modelBuilder.Entity<Clientes>().ToTable("Clientes");
            modelBuilder.Entity<Cuentas>().ToTable("Cuentas");
            modelBuilder.Entity<Entidades>().ToTable("Entidades");
            modelBuilder.Entity<TiposCuenta>().ToTable("TiposCuenta");
            modelBuilder.Entity<Prestamos>().ToTable("Prestamos");
            modelBuilder.Entity<Operaciones>().ToTable("Operaciones");
            base.OnModelCreating(modelBuilder);
        }
    }
}