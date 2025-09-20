using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_02_ITI
{
    public class Instructor
    {
        [Key]
        public int InsId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public decimal Salary { get; set; }
        public decimal HourRate { get; set; }
        public decimal Bonus { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        public int DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }

        public Department ManagedDepartment { get; set; }

        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    }
}
