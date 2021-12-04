using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Models
{
    public class ListOder
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải có tên")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Chiều dài không chính xác")]
        public string name { get; set; }
        [Required(ErrorMessage = "hãy nhập địa chỉ")]
        public string address { get; set; }
        public CartItem cart { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string sdt { get; set; }
        public DateTime ngaytao { get; set; }
        public double thanhtien { get; set; }
    }
}
