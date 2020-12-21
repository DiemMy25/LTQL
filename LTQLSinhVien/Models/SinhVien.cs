using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class SinhVien
    {
        [Key]
        [Required, MaxLength(20)]
        public string MaSV { get; set; }
        [Required, MaxLength(30)]
        public string TenSV { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        [Required, MaxLength(20)]
        public string MaLop { get; set; }
        [Required, MaxLength(20)]
        public string MaKhoa { get; set; }
        [Required, MaxLength(20)]
        public string SDT { get; set; }
        [Required, MaxLength(20)]
        public string DiaChi { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        public string role { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirm_password { get; set; }



        public virtual ICollection<DiemThi> DiemThis { get; set; }
        public virtual ICollection<Lop> Lops { get; set; }

    }
}