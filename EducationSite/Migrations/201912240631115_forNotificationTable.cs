namespace EducationSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forNotificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Long(nullable: false, identity: true),
                        NotificationText = c.String(),
                        NotificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
