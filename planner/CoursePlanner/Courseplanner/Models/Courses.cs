using System;
using System.Collections.Generic;

namespace Courseplanner.Models
{
    public partial class Courses
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TopicArea { get; set; }
        public string Semester { get; set; }
        public string PreviousCourse { get; set; }
        public bool? Compulsory { get; set; }
    }
}
