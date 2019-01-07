using Dinner.Models;
using System.Web.Mvc;

namespace Dinner.Controllers
{
    public class DinnersController : Controller
    {
        DinnerRepository dr = new DinnerRepository();

        //// GET: Dinners
        //public void Index()
        //{
        //    Response.Write("<h1>Coming  soon: Dinners</h1>");
        //    //return View();
        //}

        //public void Details(int id)
        //{   var dinner = dr.GetDinner(id);
        //    Response.Write("Details of dinner of id="+id+ " dinner details: "+dinner.Country);

        public ActionResult Details(int id =0)
        {
            var dinner = dr.GetDinner(id);
             if (dinner == null)
                return View("view not found");
             else
                return View("Details", dinner);
        }
    }
}