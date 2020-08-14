namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33f1ecca-1823-4e13-9143-14b25c934330', N'admin@vidly.com', 0, N'AOR/l2a49ej0hDUkCAuizoDSxcn6hK5G9ZpQkMNQzk4uWvwBBHmMMY7LM6ItTrAtZg==', N'64b0f8b3-a833-453f-88f1-28949c696ef2', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6328eb77-ba9e-4266-8391-877d72bc5836', N'guest@vidly.com', 0, N'APqa2U1Srti+slvtKlFTxonwx4IlfePMuxNIllGiZD67CPoe7lNGHIdmiVTpJVm5Sw==', N'74e756e8-a770-4f86-a3fc-0e6239a8e9aa', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0f745a77-ba1f-4c90-8225-ad8285342182', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33f1ecca-1823-4e13-9143-14b25c934330', N'0f745a77-ba1f-4c90-8225-ad8285342182')

");
        }
        
        public override void Down()
        {
        }
    }
}
