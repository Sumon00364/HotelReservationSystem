namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration003 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HotelImages", "Hotel_ID", "dbo.Hotels");
            DropForeignKey("dbo.HotelImages", "Images_ID", "dbo.Images");
            DropIndex("dbo.HotelImages", new[] { "Hotel_ID" });
            DropIndex("dbo.HotelImages", new[] { "Images_ID" });
            CreateIndex("dbo.Hotels", "LogoID");
            AddForeignKey("dbo.Hotels", "LogoID", "dbo.Images", "ID", cascadeDelete: true);
            DropTable("dbo.HotelImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HotelImages",
                c => new
                    {
                        Hotel_ID = c.Int(nullable: false),
                        Images_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hotel_ID, t.Images_ID });
            
            DropForeignKey("dbo.Hotels", "LogoID", "dbo.Images");
            DropIndex("dbo.Hotels", new[] { "LogoID" });
            CreateIndex("dbo.HotelImages", "Images_ID");
            CreateIndex("dbo.HotelImages", "Hotel_ID");
            AddForeignKey("dbo.HotelImages", "Images_ID", "dbo.Images", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HotelImages", "Hotel_ID", "dbo.Hotels", "ID", cascadeDelete: true);
        }
    }
}
