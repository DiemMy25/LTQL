using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class DiemThi
    {
        [Key]
        public int ID { get; set; }
        public string MaMH { get; set; }
        [Required, MaxLength(30)]
        public string KetQua { get; set; }
        public int LanThi { get; set; }
        [Required, MaxLength(20)]
        public string MaSV { get; set; }
        [ForeignKey("MaSV")]
        public virtual SinhVien SinhVien { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }

    }
}