namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingInfoes", "FullName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BookingInfoes", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BookingInfoes", "Email", c => c.String(nullable: false, maxLength: 129));
            AlterColumn("dbo.BookingInfoes", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BookingInfoes", "CheckInTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BookingInfoes", "CheckOutTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BookingInfoes", "Comments", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingInfoes", "Comments", c => c.String());
            AlterColumn("dbo.BookingInfoes", "CheckOutTime", c => c.String());
            AlterColumn("dbo.BookingInfoes", "CheckInTime", c => c.String());
            AlterColumn("dbo.BookingInfoes", "Phone", c => c.String());
            AlterColumn("dbo.BookingInfoes", "Email", c => c.String());
            AlterColumn("dbo.BookingInfoes", "Address", c => c.String());
            AlterColumn("dbo.BookingInfoes", "FullName", c => c.String());
        }
    }
}
