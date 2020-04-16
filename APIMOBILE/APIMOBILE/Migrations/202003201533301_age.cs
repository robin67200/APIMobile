namespace APIMOBILE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonorPhotoes", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.DonorPhotoes", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonorPhotoes", "Gender");
            DropColumn("dbo.DonorPhotoes", "Age");
        }
    }
}
