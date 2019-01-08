using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinner.Models
{
    public class DinnerRepository
    {

        private DBDinnerModel dbContext = new DBDinnerModel();
        public IQueryable<Dinner> FindAllDinners()
        {
            return dbContext.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners()
        {
                return from dinner in dbContext.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner; 
        }
     

        public Dinner GetDinner(int id)
        {
            return dbContext.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }


        //insert/delete methods

        public void Add(Dinner dinner)
        {
            dbContext.Dinners.Add(dinner);
        }
        //public void Delete(Dinner dinner)
        //{
        //    dbContext.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
        //    dbContext.Dinners.DeleteOnSubmit(dinner);
        //}
        ////persistence
        public void Save()
        {
            dbContext.SaveChanges();

        }
    }
}