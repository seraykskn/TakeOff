namespace RepositoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageUrl", c => c.String());
            DropColumn("dbo.Product", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Image", c => c.String());
            DropColumn("dbo.Product", "ImageUrl");
        }
    }
}
