namespace CrmBl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SellerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        SellId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CheckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checks", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Checks", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Checks", new[] { "SellerId" });
            DropIndex("dbo.Checks", new[] { "CustomerId" });
            DropTable("dbo.Sells");
            DropTable("dbo.Products");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Checks");
        }
    }
}
