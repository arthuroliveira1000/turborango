namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarEntidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Capacidade = c.Int(),
                        Categoria = c.Int(nullable: false),
                        Contato_id = c.Int(),
                        Localizacao_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Contatoes", t => t.Contato_id)
                .ForeignKey("dbo.Localizacaos", t => t.Localizacao_id)
                .Index(t => t.Contato_id)
                .Index(t => t.Localizacao_id);
            
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Site = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Localizacaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurantes", "Localizacao_id", "dbo.Localizacaos");
            DropForeignKey("dbo.Restaurantes", "Contato_id", "dbo.Contatoes");
            DropIndex("dbo.Restaurantes", new[] { "Localizacao_id" });
            DropIndex("dbo.Restaurantes", new[] { "Contato_id" });
            DropTable("dbo.Localizacaos");
            DropTable("dbo.Contatoes");
            DropTable("dbo.Restaurantes");
        }
    }
}
