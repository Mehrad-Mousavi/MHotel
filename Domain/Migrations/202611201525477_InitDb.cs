namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        HotelId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelId, t.ServiceId })
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.HotelServices", "HotelId", "dbo.Hotels");
            DropIndex("dbo.HotelServices", new[] { "ServiceId" });
            DropIndex("dbo.HotelServices", new[] { "HotelId" });
            DropTable("dbo.HotelServices");
        }
    }
}
