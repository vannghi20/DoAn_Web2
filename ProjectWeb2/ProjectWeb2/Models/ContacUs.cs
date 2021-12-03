using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Models
{
    public class ContacUs
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phải có tên")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Chiều dài không chính xác")]
        [Display(Name = "TÊN KHÁCH")] // Label hiện thị
        public string name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string gmail { get; set; }
        public string message { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string sdt { get; set; }
        public DateTime ngaytao { get; set; }
    }
}
