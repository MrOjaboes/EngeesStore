namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDateAddedFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
