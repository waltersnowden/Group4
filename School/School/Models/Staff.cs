using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Subject = new HashSet<Subject>();
        }

        public int Sid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Classes { get; set; }

        public ICollection<Subject> Subject { get; set; }
    }
}
