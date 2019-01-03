using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First_MVC_Core.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="*")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "*")]
        public string EmployeeeCity { get; set; }
        [Required(ErrorMessage = "*")]
        public string EmployeePassword { get; set; }
       
        public DateTime EmployeeDoj { get; set; }
    }
}
