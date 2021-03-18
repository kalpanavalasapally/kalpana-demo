using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Employee12Controller : Controller
    {
        EmployeeDBAccessLayer empdb = new EmployeeDBAccessLayer();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] EmployeeEntities employeeEntities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = empdb.AddEmployeeRecord(employeeEntities);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}

