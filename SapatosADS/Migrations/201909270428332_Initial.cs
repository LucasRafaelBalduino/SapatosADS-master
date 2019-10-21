namespace SapatosADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sapatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cadarco = c.Boolean(nullable: false),
                        Material = c.String(),
                        Cor = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fotografia = c.String(),
                        Tamanho = c.Int(nullable: false),
                        Modelo_Id = c.Int(nullable: false),
                        Venda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modelos", t => t.Modelo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id)
                .Index(t => t.Modelo_Id)
                .Index(t => t.Venda_Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Cpf = c.String(),
                        DataNascimento = c.DateTime(),
                        RazaoSocial = c.String(),
                        Cnpj = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdItems = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataVenda = c.DateTime(nullable: false),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id)
                .Index(t => t.Pessoa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sapatos", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Sapatos", "Modelo_Id", "dbo.Modelos");
            DropIndex("dbo.Vendas", new[] { "Pessoa_Id" });
            DropIndex("dbo.Sapatos", new[] { "Venda_Id" });
            DropIndex("dbo.Sapatos", new[] { "Modelo_Id" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Sapatos");
            DropTable("dbo.Modelos");
        }
    }
}
