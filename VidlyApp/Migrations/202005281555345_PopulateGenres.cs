namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres(Id,Name) VALUES('1','Romance')");
            Sql("INSERT INTO genres(Id,Name) VALUES('2','Action')");
            Sql("INSERT INTO genres(Id,Name) VALUES('3','Comedy')");
            Sql("INSERT INTO genres(Id,Name) VALUES('4','Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
