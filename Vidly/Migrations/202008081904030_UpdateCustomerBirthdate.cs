namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '30/1/1990' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '18/6/1963' WHERE Id = 3");
            Sql("UPDATE Customers SET Birthdate = '1/8/1974' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
