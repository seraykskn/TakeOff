namespace RepositoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.Travel", "YetkiId", "dbo.Yetki");
            AddForeignKey("dbo.User", "YetkiId", "dbo.Yetki", "YetkiId", cascadeDelete: true);
            AddForeignKey("dbo.Travel", "YetkiId", "dbo.Yetki", "YetkiId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travel", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.User", "YetkiId", "dbo.Yetki");
            AddForeignKey("dbo.Travel", "YetkiId", "dbo.Yetki", "YetkiId");
            AddForeignKey("dbo.User", "YetkiId", "dbo.Yetki", "YetkiId");
        }
    }
}
