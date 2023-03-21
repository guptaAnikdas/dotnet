using Dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dotnet.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RIndex()
        {

            var db = new ZerohungerEntities();
            var users = db.Users.ToList();
            return View(users);
        }




        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            TempData["msg"] = "Logged in successfully.";

            if (ModelState.IsValid)
            {
                using (var db = new ZerohungerEntities())
                {
                    var obj = db.Users.Where(a => a.email.Equals(user.email) && a.password.Equals(user.password)).FirstOrDefault();
                    if (obj != null)
                    {

                        if (obj.type == "Admin")
                        {
                            return RedirectToAction("AdminDashBoard");
                        }
                        else if (obj.type == "Restaurant")
                        {
                            return RedirectToAction("ResDashBoard");
                        }
                        else
                        {
                            return RedirectToAction("EmployeeDashBoard");
                        }

                    }
                }
            }
            return View(user);
        }
        public ActionResult EmployeeDashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ResDashboard()
        {
           
          
            return View();
        }

        [HttpPost]
        public ActionResult ResDashboard(Order order)
        {
            var db = new ZerohungerEntities();
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Order");
        }


        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            var db = new ZerohungerEntities();
            db.Users.Add(user);
            db.SaveChanges();
            TempData["msg"] = "Sucessfully Added";
            return RedirectToAction("RIndex");
        }
        [HttpGet]
        public ActionResult AdminDashboard()
        {
            var db = new ZerohungerEntities();
            var orders = db.Orders.ToList();
            return View(orders);
        }
        [HttpGet]
        public ActionResult RestaurantDetails()
        {
            var db = new ZerohungerEntities();
            var users = db.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult EmployeeAdmin()
        {
            var db = new ZerohungerEntities();
            var users = db.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult Order()
        {

            var db = new ZerohungerEntities();
            var orders = db.Orders.ToList();
            TempData["msg"] = "Successfully Added";
            return View(orders);
        }
        [HttpGet]
        public ActionResult AdminHistory()
        {
            var db = new ZerohungerEntities();
            var orders = db.Orders.ToList();
            return View(orders);
        }

        [HttpGet]
        public ActionResult ResturantAdmin()
        {
            var db = new ZerohungerEntities();
            var users = db.Users.ToList();
            return View(users);
        }



    }
}