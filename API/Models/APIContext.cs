using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class APIContext : DbContext
    { 
        public APIContext() : base("APIContext")
        {
        }

        public DbSet<CobroDocumento> CobroDocumentoes { get; set; }

        public DbSet<CuentaBancaria> CuentaBancarias { get; set; }
    }
}
