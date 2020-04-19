namespace RepositoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ImageName = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        ProductName = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Comment = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Yetki", t => t.YetkiId)
                .Index(t => t.UserId)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Surname = c.String(nullable: false, maxLength: 255),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Yetki", t => t.YetkiId)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Travel",
                c => new
                    {
                        TravelerId = c.Int(nullable: false, identity: true),
                        TravelerName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        FlightDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 100),
                        Size = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        YetkiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TravelerId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Yetki", t => t.YetkiId)
                .Index(t => t.UserId)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.Yetki",
                c => new
                    {
                        YetkiId = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(),
                    })
                .PrimaryKey(t => t.YetkiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.Product", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.Travel", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.Travel", "UserId", "dbo.User");
            DropForeignKey("dbo.Message", "UserId", "dbo.User");
            DropIndex("dbo.Travel", new[] { "YetkiId" });
            DropIndex("dbo.Travel", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "YetkiId" });
            DropIndex("dbo.Product", new[] { "YetkiId" });
            DropIndex("dbo.Product", new[] { "UserId" });
            DropIndex("dbo.Image", new[] { "ProductId" });
            DropTable("dbo.Yetki");
            DropTable("dbo.Travel");
            DropTable("dbo.Message");
            DropTable("dbo.User");
            DropTable("dbo.Product");
            DropTable("dbo.Image");
        }
    }
}
