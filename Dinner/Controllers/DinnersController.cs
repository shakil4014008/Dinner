using Dinner.Models;
using System.Web.Mvc;
using System.Linq;
using System;

namespace Dinner.Controllers
{
    public class DinnersController : Controller
    {
        //Remaining: 
        //post data; role, workflow

        DinnerRepository dr = new DinnerRepository();

        public ActionResult Index()
        {
            ViewBag.Welcome = "Welcome message";
            var dinner = dr.FindAllDinners().ToList();
            if (dinner == null)
                return View("View not found");
            else
                return View("Index", dinner);
            
        }

        //// GET: Dinners
        //public void Index()
        //{
        //    Response.Write("<h1>Coming  soon: Dinners</h1>");
        //    //return View();
        //}

        //public void Details(int id)
        //{   var dinner = dr.GetDinner(id);
        //    Response.Write("Details of dinner of id="+id+ " dinner details: "+dinner.Country);

        //public ActionResult Details()
        //{
        //    var dinner = dr.FindAllDinners();
        //    if (dinner == null)
        //        return View("view not found");
        //    else
        //        return View("Details", dinner);
        //}

        public ActionResult Details(int? id)
        {
            var dinner = dr.GetDinner(id ?? 0);
             if (dinner == null)
                return View("view not found");
             else
                return View("Details", dinner);
        }
        public ActionResult Edit(int? id)
        {
            var dinner = dr.GetDinner(id ?? 0);
            if (dinner == null)
                return View("view not found");
            else
                return View("Edit", dinner);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var dinner = dr.GetDinner(id);
            //dinner.Title = Request.Form["Title"];
            //dinner.Description = Request.Form["Description"];
            //dinner.EventDate = DateTime.Parse(Request.Form["EventDate"]);
            //dinner.Address = Request.Form["Address"];
            //dinner.Country = Request.Form["Country"];
            //dinner.ContactPhone = Request.Form["ContactPhone"];
            //dr.Save();
            try
            {
                UpdateModel(dinner);
                dr.Save();
                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            catch {
                //foreach(var issue in dinner.get)//addModelError
                return View(dinner);
            }

        }
    }
}