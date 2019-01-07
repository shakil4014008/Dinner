using Dinner.Models;
using System.Web.Mvc;
using System.Linq;

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
            //var dinner = dr.FindUpcomingDinners().ToList();
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

        public ActionResult Details(int id =0)
        {
            var dinner = dr.GetDinner(id);
             if (dinner == null)
                return View("view not found");
             else
                return View("Details", dinner);
        }
        public ActionResult Edit(int id = 0)
        {
            var dinner = dr.GetDinner(id);
            if (dinner == null)
                return View("view not found");
            else
                return View("Edit", dinner);
        }
    }
}