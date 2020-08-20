namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "MovieImage");
            //DropTable("dbo.Images");
        }
        
       public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImageName = c.String(),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieImage", c => c.String());
        }
    }
}
