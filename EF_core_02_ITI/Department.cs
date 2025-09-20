using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_02_ITI
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required, MaxLength(100)]
        public string DeptName { get; set; }

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public int ManagerId { get; set; }
        [ForeignKey(nameof(ManagerId))]
        public Instructor Manager { get; set; }

        public DateTime ManagerHiringDate { get; set; }
    }
}
