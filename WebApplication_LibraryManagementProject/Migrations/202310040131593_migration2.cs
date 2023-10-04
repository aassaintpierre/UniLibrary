namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookHistories", "ReturnDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookHistories", "ReturnDate");
        }
    }
}
