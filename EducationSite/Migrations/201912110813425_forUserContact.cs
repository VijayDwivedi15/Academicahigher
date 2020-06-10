namespace EducationSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forUserContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        ContactID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        ContactDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactForms");
        }
    }
}
