namespace BankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioDeMigraciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CobroDocumentos",
                c => new
                    {
                        IdCobroDocumento = c.Int(nullable: false, identity: true),
                        Documento = c.Int(nullable: false),
                        NumeroCuenta = c.String(nullable: false, maxLength: 10),
                        CantidadCobro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MesDePago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCobroDocumento)
                .ForeignKey("dbo.CuentaBancariaClientes", t => t.NumeroCuenta, cascadeDelete: true)
                .Index(t => t.NumeroCuenta);
            
            CreateTable(
                "dbo.CuentaBancariaClientes",
                c => new
                    {
                        NumeroCuenta = c.String(nullable: false, maxLength: 10),
                        NombreCuenta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroCuenta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CobroDocumentos", "NumeroCuenta", "dbo.CuentaBancariaClientes");
            DropIndex("dbo.CobroDocumentos", new[] { "NumeroCuenta" });
            DropTable("dbo.CuentaBancariaClientes");
            DropTable("dbo.CobroDocumentos");
        }
    }
}
