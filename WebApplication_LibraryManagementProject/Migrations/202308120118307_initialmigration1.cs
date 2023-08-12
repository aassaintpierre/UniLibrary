namespace WebApplication_LibraryManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            AddColumn("dbo.Members", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Members", "Access", c => c.String());
            AlterColumn("dbo.Members", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Members", "DateOfBirth");
            DropColumn("dbo.Members", "ContactNo");
            DropColumn("dbo.Members", "Country");
            DropColumn("dbo.Members", "City");
            DropColumn("dbo.Members", "Pincode");
            DropColumn("dbo.Members", "FullAddress");
            DropTable("dbo.Authors");
            DropTable("dbo.Publishers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "FullAddress", c => c.String());
            AddColumn("dbo.Members", "Pincode", c => c.String());
            AddColumn("dbo.Members", "City", c => c.String());
            AddColumn("dbo.Members", "Country", c => c.String());
            AddColumn("dbo.Members", "ContactNo", c => c.String());
            AddColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "FullName", c => c.String());
            DropColumn("dbo.Members", "Access");
            DropColumn("dbo.Members", "Username");
            CreateIndex("dbo.Books", "PublisherId");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id");
        }
    }
}
