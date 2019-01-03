using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_Core.Models
{
    public class LoginModel
    {
        [Display(Name ="Login ID")]
        [Required(ErrorMessage ="*")]

        public int LoginID { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
