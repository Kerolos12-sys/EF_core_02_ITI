using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core_02_ITI
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Required, MaxLength(100)]
        public string TopName { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
