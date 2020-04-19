namespace RepositoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "YetkiId", "dbo.Yetki");
            AddForeignKey("dbo.Product", "YetkiId", "dbo.Yetki", "YetkiId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "YetkiId", "dbo.Yetki");
            AddForeignKey("dbo.Product", "YetkiId", "dbo.Yetki", "YetkiId");
        }
    }
}
