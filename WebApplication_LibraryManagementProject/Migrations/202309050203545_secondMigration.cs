namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookIssues", "IssueDate", c => c.String());
            AlterColumn("dbo.BookIssues", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookIssues", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookIssues", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
