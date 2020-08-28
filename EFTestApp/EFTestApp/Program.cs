using System;
using System.Linq;
using System.Windows.Markup;
using EFTestApp.Models;
using AppContext = EFTestApp.Models.AppContext;

namespace EFTestApp
{
    public static class Program
    {
        public static void Main()
        {
            using (AppContext db = new AppContext())
            {
                Company ts = new Company { Name = "TimelySoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(ts, google);
                db.SaveChanges();

                User nurs = new User { Name = "Nursultan", Company = ts };
                User aman = new User { Name = "Amangeldi", Company = ts };
                User sezim = new User { Name = "Sezim", Company = google };
                User unknown = new User { Name = "X3", Company = google };
                db.Users.AddRange(nurs, aman, sezim, unknown);
                db.SaveChanges();

                var users = db.Users.ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name}");
                }

                var comp = db.Companies.FirstOrDefault(x => x == google);
                db.Companies.RemoveRange(comp);
                db.SaveChanges();

                var newusers = db.Users.ToList();
                foreach (var user in newusers)
                {
                    Console.WriteLine($"{user.Name}");
                }

            }
        }
    }
}
