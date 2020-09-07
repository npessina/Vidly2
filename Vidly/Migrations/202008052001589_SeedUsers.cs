namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5e47b7a3-e192-475c-8970-40a9d0782dcc', N'admin@vidly.com', 0, N'AImThWXQVmZTFsVpCi7YTQbYPi9Vnqj597klgmdn/Drnd1IAy62Sb+op0evR2N+BOA==', N'7506ae76-4fb2-4947-9da2-edb6352e275b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b16c010f-fc78-41f5-a1b0-1b20dc85662d', N'guest@vidly.com', 0, N'AFYJhH0jLo9Ryhrnq7hs7DSMwlihE5J5pESuUj5OYVLslDR9aWbrp9En5MiRtkzE7A==', N'61fe61d0-1497-4554-8a68-6b40412aa12b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e24c9169-73ca-4d80-834e-a5958729c35a', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e47b7a3-e192-475c-8970-40a9d0782dcc', N'e24c9169-73ca-4d80-834e-a5958729c35a')
");
        }

        public override void Down()
        {
        }
    }
}
