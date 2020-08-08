namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Mvc.Ajax;

    public partial class Genre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Animated Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Animated Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
