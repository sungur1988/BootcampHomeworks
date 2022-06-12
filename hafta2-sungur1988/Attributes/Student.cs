using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Table("Student")]
    public class Student
    {
        [Column("Name",typeof(string),true)]
        public string? Name { get; set; }
        [Column("Age", typeof(int), false)]
        public int Age { get; set; }
        [Column("Birthday", typeof(DateTime), false)]
        public DateTime? Birthday { get; set; }

    }
}
