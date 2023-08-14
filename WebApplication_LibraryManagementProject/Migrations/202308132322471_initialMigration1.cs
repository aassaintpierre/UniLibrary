namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookIssues", "MemberId", "dbo.Members");
            DropIndex("dbo.BookIssues", new[] { "MemberId" });
            DropPrimaryKey("dbo.Members");
            AddColumn("dbo.BookIssues", "Member_Username", c => c.String(maxLength: 128));
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Members", "Access", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "AccountStatus", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Members", "Username");
            CreateIndex("dbo.BookIssues", "Member_Username");
            AddForeignKey("dbo.BookIssues", "Member_Username", "dbo.Members", "Username");
            DropColumn("dbo.Books", "PublishDate");
            DropColumn("dbo.Books", "Edition");
            DropColumn("dbo.Books", "BookCost");
            DropColumn("dbo.Books", "NoOfPages");
            DropColumn("dbo.Books", "BookDescription");
            DropColumn("dbo.Books", "PublisherId");
            DropColumn("dbo.Members", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Books", "PublisherId", c => c.String());
            AddColumn("dbo.Books", "BookDescription", c => c.String());
            AddColumn("dbo.Books", "NoOfPages", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "BookCost", c => c.Double(nullable: false));
            AddColumn("dbo.Books", "Edition", c => c.String());
            AddColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.BookIssues", "Member_Username", "dbo.Members");
            DropIndex("dbo.BookIssues", new[] { "Member_Username" });
            DropPrimaryKey("dbo.Members");
            AlterColumn("dbo.Members", "AccountStatus", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Access", c => c.String());
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false));
            DropColumn("dbo.BookIssues", "Member_Username");
            AddPrimaryKey("dbo.Members", "Id");
            CreateIndex("dbo.BookIssues", "MemberId");
            AddForeignKey("dbo.BookIssues", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
