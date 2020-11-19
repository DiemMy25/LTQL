using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class Lop
    {
        [Key]
        [Required, MaxLength(20)]
        public string MaLop { get; set; }
        [Required, MaxLength(20)]
        public string TenLop { get; set; }
        [Required, MaxLength(20)]
        public string MaKhoa { get; set; }
        public SinhVien SinhVien { get; set; }
        public ICollection<Khoa> Khoas { get; set; }

    }
}