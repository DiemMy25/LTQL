using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class Khoa
    {
        [Key]
        [Required, MaxLength(20)]
        public string MaKhoa { get; set; }
        [Required, MaxLength(20)]
        public string TenKhoa { get; set; }
        public virtual Lop Lop { get; set; }
        public virtual ICollection<GiangVien> GiangViens { get; set; }

    }
}