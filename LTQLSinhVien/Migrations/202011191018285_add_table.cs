namespace LTQLSinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiemThis",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 20),
                        MaMH = c.String(nullable: false, maxLength: 20),
                        KetQua = c.String(nullable: false, maxLength: 30),
                        LanThi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSV)
                .ForeignKey("dbo.SinhViens", t => t.MaSV)
                .Index(t => t.MaSV);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 20),
                        TenMonHoc = c.String(nullable: false, maxLength: 20),
                        SoTC = c.String(nullable: false, maxLength: 20),
                        DiemThi_MaSV = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaMH)
                .ForeignKey("dbo.DiemThis", t => t.DiemThi_MaSV)
                .Index(t => t.DiemThi_MaSV);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 20),
                        TenSV = c.String(nullable: false, maxLength: 30),
                        GioiTinh = c.String(),
                        NgaySinh = c.String(),
                        MaLop = c.String(nullable: false, maxLength: 20),
                        MaKhoa = c.String(nullable: false, maxLength: 20),
                        SDT = c.String(nullable: false, maxLength: 20),
                        DiaChi = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MaSV);
            
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 20),
                        TenLop = c.String(nullable: false, maxLength: 20),
                        MaKhoa = c.String(nullable: false, maxLength: 20),
                        SinhVien_MaSV = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaLop)
                .ForeignKey("dbo.SinhViens", t => t.SinhVien_MaSV)
                .Index(t => t.SinhVien_MaSV);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        MaKhoa = c.String(nullable: false, maxLength: 20),
                        TenKhoa = c.String(nullable: false, maxLength: 20),
                        Lop_MaLop = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaKhoa)
                .ForeignKey("dbo.Lops", t => t.Lop_MaLop)
                .Index(t => t.Lop_MaLop);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 20),
                        TenGV = c.String(nullable: false, maxLength: 20),
                        MaKhoa = c.String(nullable: false, maxLength: 20),
                        MaLop = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MaGV)
                .ForeignKey("dbo.Khoas", t => t.MaKhoa, cascadeDelete: true)
                .Index(t => t.MaKhoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lops", "SinhVien_MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.Khoas", "Lop_MaLop", "dbo.Lops");
            DropForeignKey("dbo.GiangViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.DiemThis", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.MonHocs", "DiemThi_MaSV", "dbo.DiemThis");
            DropIndex("dbo.GiangViens", new[] { "MaKhoa" });
            DropIndex("dbo.Khoas", new[] { "Lop_MaLop" });
            DropIndex("dbo.Lops", new[] { "SinhVien_MaSV" });
            DropIndex("dbo.MonHocs", new[] { "DiemThi_MaSV" });
            DropIndex("dbo.DiemThis", new[] { "MaSV" });
            DropTable("dbo.GiangViens");
            DropTable("dbo.Khoas");
            DropTable("dbo.Lops");
            DropTable("dbo.SinhViens");
            DropTable("dbo.MonHocs");
            DropTable("dbo.DiemThis");
        }
    }
}
