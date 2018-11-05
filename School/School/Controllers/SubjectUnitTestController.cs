using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
namespace School.Controllers
{
    public class SubjectUnitTestController : Controller
    {
        [NonAction]
        public List<Subject> GetSubjectList()
        {
            return new List<Subject>
            {      new Subject
                {
                    Sid = 18101,
                  SubjectId = 1,
                  SubjectName = "Programming",
                  Description = "C#",
                  Year = 2018,
                  Semester = 1
                },
                new Subject
                {
                       Sid = 18102,
                  SubjectId = 1,
                  SubjectName = "Networks",
                  Description = "Networking",
                  Year = 2018,
                  Semester = 2
                },
            };
        }
        public IActionResult Index()
        {
            var subjects = from s in GetSubjectList() select s;
            return View(subjects);
        }

        public IActionResult Subjects()
        {
            var subjects = from e in GetSubjectList()
                         orderby e.Sid
                         select e;
            return View(subjects);
        }
    }
}
