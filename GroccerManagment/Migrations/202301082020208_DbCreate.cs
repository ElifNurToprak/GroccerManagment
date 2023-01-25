namespace GroccerManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fruits", "Barcode", c => c.String());
            AddColumn("dbo.Vegetables", "Barcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vegetables", "Barcode");
            DropColumn("dbo.Fruits", "Barcode");
        }
    }
}
