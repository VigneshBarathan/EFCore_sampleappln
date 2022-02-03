using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_sample.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }

        public ICollection<Address> EmployeeAddress { get; set; }
                    = new List<Address>();

        public float Salary { get; set; }
    }
}
