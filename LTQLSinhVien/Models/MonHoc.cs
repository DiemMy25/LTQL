using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class MonHoc
    {
        [Key]
        [Required, MaxLength(20)]
        public string MaMH { get; set; }
        [Required, MaxLength(20)]
        public string TenMonHoc { get; set; }
        [Required, MaxLength(20)]
        public string SoTC { get; set; }
        public DiemThi DiemThi { get; set; }

    }
}