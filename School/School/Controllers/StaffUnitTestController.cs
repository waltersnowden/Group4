using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
namespace School.Controllers
{
    public class StaffUnitTestController : Controller
    {
        [NonAction]
        public List<Staff> GetStaffList()
        {
            return new List<Staff>
            {      new Staff
                {
                    Sid = 18101,
                    Name = "John Smith",
                    Age = 21,
                    Phone = "021 123456",
                },
                new Staff
                {
                    Sid = 18102,
                    Name = "Peter Price",
                    Age = 20,
                    Phone = "020 123456",
                },
            };
        }
        public IActionResult Index()
        {
            var staffs = from s in GetStaffList() select s;
            return View(staffs);
        }

        public IActionResult Staff()
        {
            var staffs = from e in GetStaffList()
                           orderby e.Sid
                           select e;
            return View(staffs);
        }
    }
}
