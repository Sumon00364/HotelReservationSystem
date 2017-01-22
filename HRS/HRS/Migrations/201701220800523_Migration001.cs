namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 129),
                        Phone = c.String(nullable: false, maxLength: 50),
                        CheckInTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        Comments = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 129),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GallaryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ImageUrl = c.String(nullable: false, maxLength: 150),
                        Price = c.Double(nullable: false),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gallaries", t => t.GallaryID, cascadeDelete: true)
                .Index(t => t.GallaryID);
            
            CreateTable(
                "dbo.Gallaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 129),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        Fax = c.String(nullable: false, maxLength: 50),
                        Website = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                        HotelImage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartnerImage = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 129),
                        Website = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.User_ID })
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.RoomTypeFacilities",
                c => new
                    {
                        RoomType_ID = c.Int(nullable: false),
                        Facilities_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomType_ID, t.Facilities_ID })
                .ForeignKey("dbo.RoomTypes", t => t.RoomType_ID, cascadeDelete: true)
                .ForeignKey("dbo.Facilities", t => t.Facilities_ID, cascadeDelete: true)
                .Index(t => t.RoomType_ID)
                .Index(t => t.Facilities_ID);
            
            CreateTable(
                "dbo.ImagesGallaries",
                c => new
                    {
                        Images_ID = c.Int(nullable: false),
                        Gallary_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Images_ID, t.Gallary_ID })
                .ForeignKey("dbo.Images", t => t.Images_ID, cascadeDelete: true)
                .ForeignKey("dbo.Gallaries", t => t.Gallary_ID, cascadeDelete: true)
                .Index(t => t.Images_ID)
                .Index(t => t.Gallary_ID);
            
            CreateTable(
                "dbo.PartnersHotels",
                c => new
                    {
                        Partners_ID = c.Int(nullable: false),
                        Hotel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Partners_ID, t.Hotel_ID })
                .ForeignKey("dbo.Partners", t => t.Partners_ID, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_ID, cascadeDelete: true)
                .Index(t => t.Partners_ID)
                .Index(t => t.Hotel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PartnersHotels", "Hotel_ID", "dbo.Hotels");
            DropForeignKey("dbo.PartnersHotels", "Partners_ID", "dbo.Partners");
            DropForeignKey("dbo.RoomTypes", "GallaryID", "dbo.Gallaries");
            DropForeignKey("dbo.Services", "ImageID", "dbo.Images");
            DropForeignKey("dbo.ImagesGallaries", "Gallary_ID", "dbo.Gallaries");
            DropForeignKey("dbo.ImagesGallaries", "Images_ID", "dbo.Images");
            DropForeignKey("dbo.RoomTypeFacilities", "Facilities_ID", "dbo.Facilities");
            DropForeignKey("dbo.RoomTypeFacilities", "RoomType_ID", "dbo.RoomTypes");
            DropForeignKey("dbo.RoleUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.BookingInfoes", "UserID", "dbo.Users");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.PartnersHotels", new[] { "Hotel_ID" });
            DropIndex("dbo.PartnersHotels", new[] { "Partners_ID" });
            DropIndex("dbo.RoomTypes", new[] { "GallaryID" });
            DropIndex("dbo.Services", new[] { "ImageID" });
            DropIndex("dbo.ImagesGallaries", new[] { "Gallary_ID" });
            DropIndex("dbo.ImagesGallaries", new[] { "Images_ID" });
            DropIndex("dbo.RoomTypeFacilities", new[] { "Facilities_ID" });
            DropIndex("dbo.RoomTypeFacilities", new[] { "RoomType_ID" });
            DropIndex("dbo.RoleUsers", new[] { "User_ID" });
            DropIndex("dbo.RoleUsers", new[] { "Role_ID" });
            DropIndex("dbo.BookingInfoes", new[] { "UserID" });
            DropTable("dbo.PartnersHotels");
            DropTable("dbo.ImagesGallaries");
            DropTable("dbo.RoomTypeFacilities");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Partners");
            DropTable("dbo.Hotels");
            DropTable("dbo.Services");
            DropTable("dbo.Images");
            DropTable("dbo.Gallaries");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Facilities");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.BookingInfoes");
        }
    }
}
