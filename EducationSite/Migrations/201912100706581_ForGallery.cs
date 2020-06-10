namespace EducationSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryID = c.Long(nullable: false, identity: true),
                        Images = c.String(),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.GalleryID);
            
            AddColumn("dbo.AddFaculties", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddFaculties", "CreatedBy");
            DropTable("dbo.Galleries");
        }
    }
}
