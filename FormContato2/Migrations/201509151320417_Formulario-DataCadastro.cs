namespace FormContato2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormularioDataCadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.formulario_contatos", "DataCadastro", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.formulario_contatos", "DataCadastro");
        }
    }
}
