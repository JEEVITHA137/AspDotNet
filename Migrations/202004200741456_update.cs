namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            {
                Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id],[DrivingLicense], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a4c8fb40-a753-488a-8fd3-1839ebdfb57c',1234, N'jeevithsakthi137@gmail.com', 0, N'ALH1G/kJxv/nBmhftedcK0ceLlzb5Y0yezJpXP0AB1MKXIc4Orz4hDkoAhfEcygUqQ==', N'e7b05c0e-e77e-4d89-8db1-2a86c5b53aef', NULL, 0, 0, NULL, 1, 0, N'jeevithsakthi137@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense],[Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4f28f5f-8583-47a8-aade-34cfeb08d2b3',199, N'admin@gmail.com', 0, N'AMcFng2uFDkhUjGekZ+Qme+Oj+CJlmS1inVT/Wjo2D4ODChAGgBsYZ3RdWOGOYUPxw==', N'bdc52d7f-6c4e-48aa-acb2-3f0ace6a077b', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a998debb-e0c3-45ec-895b-10527494fcd9', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4f28f5f-8583-47a8-aade-34cfeb08d2b3', N'a998debb-e0c3-45ec-895b-10527494fcd9')

");
            }
        }
        
        public override void Down()
        {
        }
    }
}
