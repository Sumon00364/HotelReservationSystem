namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingInfoes", "CheckInTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingInfoes", "CheckOutTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingInfoes", "CheckOutTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BookingInfoes", "CheckInTime", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
