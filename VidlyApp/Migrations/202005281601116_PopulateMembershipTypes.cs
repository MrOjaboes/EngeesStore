namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES('1','PAY AS YOU GO','0','0','0')");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES('2','MONTHLY','30','1','10')");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES('3','QUARTERLY','90','3','15')");
            Sql("INSERT INTO MembershipTypes(Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES('4','ANNUALLY','300','12','20')");

        }
        
        public override void Down()
        {
        }
    }
}
