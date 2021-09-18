namespace udb_dse_desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.clientes", "Telefono", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.clientes", "Correo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.clientes", "Correo", c => c.String());
            AlterColumn("dbo.clientes", "Telefono", c => c.String());
        }
    }
}
