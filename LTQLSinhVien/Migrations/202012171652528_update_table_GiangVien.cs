namespace LTQLSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_GiangVien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiangViens", "email", c => c.String(nullable: false));
            AddColumn("dbo.GiangViens", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiangViens", "password");
            DropColumn("dbo.GiangViens", "email");
        }
    }
}
