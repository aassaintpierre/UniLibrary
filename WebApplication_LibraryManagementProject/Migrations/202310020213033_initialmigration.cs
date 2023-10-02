namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AdminLogins", newName: "SuperAdmins");
            RenameTable(name: "dbo.BookIssues", newName: "BookHistories");
            AddColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.SuperAdmins", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.BookHistories", "IssueDate", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Language", c => c.String(nullable: false));
            DropColumn("dbo.Books", "IsbnCode");
            DropColumn("dbo.Books", "Name");
            DropColumn("dbo.Books", "BookImgLink");
            DropColumn("dbo.Books", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorId", c => c.String());
            AddColumn("dbo.Books", "BookImgLink", c => c.String());
            AddColumn("dbo.Books", "Name", c => c.String());
            AddColumn("dbo.Books", "IsbnCode", c => c.String());
            AlterColumn("dbo.Books", "Language", c => c.String());
            AlterColumn("dbo.BookHistories", "IssueDate", c => c.String());
            AlterColumn("dbo.SuperAdmins", "FullName", c => c.String());
            DropColumn("dbo.Books", "Author");
            DropColumn("dbo.Books", "Title");
            RenameTable(name: "dbo.BookHistories", newName: "BookIssues");
            RenameTable(name: "dbo.SuperAdmins", newName: "AdminLogins");
        }
    }
}
