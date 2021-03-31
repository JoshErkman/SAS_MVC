namespace SAS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wrongCreatedUTCName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scripture", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Scripture", "guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scripture", "guid", c => c.Guid(nullable: false));
            DropColumn("dbo.Scripture", "OwnerId");
        }
    }
}
