namespace SAS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsStarred : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scripture", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scripture", "IsStarred");
        }
    }
}
