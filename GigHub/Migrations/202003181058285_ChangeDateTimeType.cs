namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime(nullable: false));
        }
    }
}
