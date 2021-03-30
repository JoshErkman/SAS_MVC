namespace SAS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptureUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scripture", "Book", c => c.String(nullable: false));
            AddColumn("dbo.Scripture", "Chapter", c => c.Int(nullable: false));
            AddColumn("dbo.Scripture", "Verses", c => c.String(nullable: false));
            DropColumn("dbo.Scripture", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scripture", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Scripture", "Verses");
            DropColumn("dbo.Scripture", "Chapter");
            DropColumn("dbo.Scripture", "Book");
        }
    }
}
