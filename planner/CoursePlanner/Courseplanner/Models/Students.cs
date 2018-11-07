using System;
using System.Collections.Generic;

namespace Courseplanner.Models
{
    public partial class Students
    {
        public Students()
        {
            StudyPlans = new HashSet<StudyPlans>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public ICollection<StudyPlans> StudyPlans { get; set; }
    }
}
