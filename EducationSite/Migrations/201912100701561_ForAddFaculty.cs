namespace EducationSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForAddFaculty : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.AddFaculties",
                c => new
                    {
                        FacultyID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Qualification = c.String(),
                        Experience = c.String(),
                        Age = c.Int(nullable: false),
                        ExpertiesIn = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            
        }
        
        public override void Down()
        {
          
            
            DropTable("dbo.AddFaculties");
           
        }
    }
}
