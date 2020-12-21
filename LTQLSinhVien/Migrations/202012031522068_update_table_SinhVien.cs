namespace LTQLSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_SinhVien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "email", c => c.String(nullable: false));
            AddColumn("dbo.SinhViens", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "password");
            DropColumn("dbo.SinhViens", "email");
        }
    }
}
