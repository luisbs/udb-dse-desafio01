namespace udb_dse_desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrarion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cuenta_tipos", "TipoCuenta", c => c.String(nullable: false));
            AlterColumn("dbo.transacciones_tipos", "TipoTransaccion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.transacciones_tipos", "TipoTransaccion", c => c.String());
            AlterColumn("dbo.cuenta_tipos", "TipoCuenta", c => c.String());
        }
    }
}
