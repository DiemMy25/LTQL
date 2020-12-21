namespace LTQLSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiangViens", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiangViens", "role");
        }
    }
}
