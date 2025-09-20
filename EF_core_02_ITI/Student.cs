
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_02_ITI
{
    public class Student
    {
        [Key]
        public int StId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        public int DeptId { get; set; }

       // [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
