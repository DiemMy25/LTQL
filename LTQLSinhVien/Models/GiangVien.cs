using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQLSinhVien.Models
{
    public class GiangVien
    {
        [Key]
        [Required, MaxLength(20)]
        public string MaGV { get; set; }
        [Required, MaxLength(20)]
        public string TenGV { get; set; }
        [Required, MaxLength(20)]
        public string MaKhoa { get; set; }
        [Required, MaxLength(20)]
        public string MaLop { get; set; }
        public string role { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public virtual Khoa Khoa { get; set; }

    }
}