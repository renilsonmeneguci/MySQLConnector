namespace FormContato2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.formulario_contatos",
                c => new
                    {
                        FormularioId = c.Int(nullable: false, identity: true),
                        Empresa = c.String(nullable: false, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Telefone = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.FormularioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.formulario_contatos");
        }
    }
}
