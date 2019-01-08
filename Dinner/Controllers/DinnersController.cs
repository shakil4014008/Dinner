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

        DinnerRepository dinnerRepository = new DinnerRepository();

        public ActionResult Index()
        {
            ViewBag.Welcome = "Welcome message";
            var dinner = dinnerRepository.FindAllDinners().ToList();
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
            var dinner = dinnerRepository.GetDinner(id ?? 0);
             if (dinner == null)
                return View("view not found");
             else
                return View("Details", dinner);
        }
        public ActionResult Edit(int? id)
        {
            var dinner = dinnerRepository.GetDinner(id ?? 0);
            if (dinner == null)
                return View("view not found");
            else
                return View("Edit", dinner);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var dinner = dinnerRepository.GetDinner(id);
            
            try
            {
                UpdateModel(dinner);
                dinnerRepository.Save();
                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            catch {
                //foreach(var issue in dinner.get)//addModelError
                return View(dinner);
            }
        }

        //GET Dinner/Create
        public ActionResult Create()
        {
            var dinner = new Models.Dinner()
            {
                EventDate = DateTime.Now.AddDays(7)
            };
            return View(dinner);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Models.Dinner dinner)
        {
           
            
            if(ModelState.IsValid) 
            {
                UpdateModel(dinner);
                dinnerRepository.Add(dinner);
                dinnerRepository.Save();
                return RedirectToAction("Index", dinner);
            }
            return View(dinner);
        }


    
   }
}