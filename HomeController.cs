using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_MVC_Core.Models;
using Microsoft.AspNetCore.Http;//session
using Microsoft.AspNetCore.Mvc;
using First_MVC_Core.Services;

namespace First_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        Iservice dep;
        MyDbContext db;
        public HomeController(Iservice dep,MyDbContext db)
        {
            this.dep = dep;
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var count = db.Employees.Count(e => e.EmployeeID == model.LoginID && e.EmployeePassword == model.Password);
                if(count>0)
                {
                   HttpContext.Session.SetString("LoginID", model.LoginID.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msg = "Invalid ID Or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Index()
        {
            string guid = dep.GetGuidID();
            int sum = dep.GetSum(10, 20);
            ViewBag.msg1 = "Result :" + sum;
            ViewBag.msg2 = guid;

            ViewBag.msg = "Login ID:" + HttpContext.Session.GetString("LoginID");
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(model);
                db.SaveChanges();
                ViewBag.msg = "Employee ID:" + model.EmployeeID;
                return View();
            }
            else
            {
                ViewBag.msg = "Validation Error";
                return View();
            }
        }

        public IActionResult GetEmployees()
        {
            var model = db.Employees.ToList();
            return View(model);
        }
    }
}