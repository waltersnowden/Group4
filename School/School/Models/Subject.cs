using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Subject
    {
        public int Sid { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public int? Semester { get; set; }

        public Staff S { get; set; }
    }
}
