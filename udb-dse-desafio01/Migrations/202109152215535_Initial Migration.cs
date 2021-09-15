namespace udb_dse_desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        PrimerApellido = c.String(),
                        SegundoApellido = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Moneda = c.String(),
                        IdCliente = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.cuenta_tipos", t => t.Tipo, cascadeDelete: true)
                .Index(t => t.IdCliente)
                .Index(t => t.Tipo);
            
            CreateTable(
                "dbo.cuenta_tipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoCuenta = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.transacciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        Estado = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        FechaAplicacion = c.DateTime(nullable: false),
                        IdCuentaBancaria = c.Int(nullable: false),
                        TipoTransaccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cuentas", t => t.IdCuentaBancaria, cascadeDelete: true)
                .ForeignKey("dbo.transacciones_tipos", t => t.TipoTransaccion, cascadeDelete: true)
                .Index(t => t.IdCuentaBancaria)
                .Index(t => t.TipoTransaccion);
            
            CreateTable(
                "dbo.transacciones_tipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoTransaccion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transacciones", "TipoTransaccion", "dbo.transacciones_tipos");
            DropForeignKey("dbo.transacciones", "IdCuentaBancaria", "dbo.cuentas");
            DropForeignKey("dbo.cuentas", "Tipo", "dbo.cuenta_tipos");
            DropForeignKey("dbo.cuentas", "IdCliente", "dbo.clientes");
            DropIndex("dbo.transacciones", new[] { "TipoTransaccion" });
            DropIndex("dbo.transacciones", new[] { "IdCuentaBancaria" });
            DropIndex("dbo.cuentas", new[] { "Tipo" });
            DropIndex("dbo.cuentas", new[] { "IdCliente" });
            DropTable("dbo.transacciones_tipos");
            DropTable("dbo.transacciones");
            DropTable("dbo.cuenta_tipos");
            DropTable("dbo.cuentas");
            DropTable("dbo.clientes");
        }
    }
}
