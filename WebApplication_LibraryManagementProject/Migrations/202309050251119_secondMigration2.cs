namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookIssues", "Member_Username", "dbo.Members");
            DropIndex("dbo.BookIssues", new[] { "Member_Username" });
            DropColumn("dbo.BookIssues", "DueDate");
            DropColumn("dbo.BookIssues", "Member_Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookIssues", "Member_Username", c => c.String(maxLength: 128));
            AddColumn("dbo.BookIssues", "DueDate", c => c.String());
            CreateIndex("dbo.BookIssues", "Member_Username");
            AddForeignKey("dbo.BookIssues", "Member_Username", "dbo.Members", "Username");
        }
    }
}
