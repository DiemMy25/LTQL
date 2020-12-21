namespace LTQLSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_rolecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "role");
        }
    }
}
