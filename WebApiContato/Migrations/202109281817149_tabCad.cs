namespace WebApiContato.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabCad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 40),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Local = c.String(maxLength: 150),
                        Cidade = c.String(maxLength: 100),
                        Estado = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatoes", "EnderecoId", "dbo.Enderecoes");
            DropIndex("dbo.Contatoes", new[] { "EnderecoId" });
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Contatoes");
        }
    }
}
