using System;
using System.Collections.Generic;

namespace Courseplanner.Models
{
    public partial class StudyPlans
    {
        public int PlanId { get; set; }
        public int StudentId { get; set; }
        public string Papers { get; set; }

        public Students Student { get; set; }
    }
}
