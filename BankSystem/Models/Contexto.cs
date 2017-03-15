using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankSystem.Models
{
    public class Contexto: DbContext
    {
        public Contexto()
            : base("Default")
        {

        }

        public DbSet<CobroDocumento> CobroDocumento { get; set; }
        public DbSet<CuentaBancaria> CuentaBancaria { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Llaves primarias
        //    modelBuilder.Entity<CobroDocumento>().HasKey(x => x.Id);
        //    modelBuilder.Entity<CuentaBancaria>().HasKey(x => x.IdCuenta);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}