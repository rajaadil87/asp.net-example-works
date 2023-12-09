using firstapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstapplication.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult newview()
        {
            return View();
        }
        public ActionResult form()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult form(FormCollection form)
        //{

        //    var Email = form["email"];
        //    ViewBag.email = Email;
        //    var Firstname = form["firstname"];
        //    ViewBag.firstname = Firstname;
        //    var Lastname = form["lastname"];
        //    ViewBag.lastname = Lastname;
        //    var Password = form["pass"];
        //    ViewBag.pass = Password;
        //    var Confirmpass = form["confirmpass"];
        //    ViewBag.confirmpass = Confirmpass;

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult form(FormCollection form)
        //{

        //    var Email = form["email"];
        //    var Firstname = form["firstname"];
        //    var Lastname = form["lastname"];
        //    var Password = form["pass"];
        //    var Confirmpass = form["confirmpass"];


        //    List<string> itemList = Session["items"] as List<string> ?? new List<string>();
        //    itemList.Add(Email);
        //    itemList.Add(Firstname);
        //    itemList.Add(Lastname);
        //    itemList.Add(Password);
        //    itemList.Add(Confirmpass);

        //    Session["items"] = itemList;
        //    return RedirectToAction("form");

        //}

        [HttpPost]
        public ActionResult form(loginform model)
        {
            if (ModelState.IsValid)
            {
                var Email = model.Email;
                var firstname = model.firstname;
                var lastname = model.lastname;
                var password = model.pass;
                var confirmpass = model.confirmpass;

                List<loginform> itemlist = Session["loginform"] as List<loginform> ?? new List<loginform>();

                itemlist.Add(model);
                Session["loginform"] = itemlist;
            }
            //return View("form");
            return RedirectToAction("form");


        }


        [HttpPost]
        public ActionResult signinform(Signin model)
        {
            if (ModelState.IsValid)
            {
                var Email = model.Email;
                var password = model.pass;

                Signin savedloginform = Session["Signin"] as Signin;
                
                if(savedloginform != null)
                {
                    if(savedloginform.Email == model.Email && savedloginform.pass == model.pass)
                    {
                        return RedirectToAction("form");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid credentials provided for sign-in.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No login information found. Please fill out the login form first.");
                }

            }
            //return View("form");
            return RedirectToAction("form");
        }
    }
}