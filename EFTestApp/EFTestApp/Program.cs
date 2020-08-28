using System;
using System.Linq;
using System.Windows.Markup;
using EFTestApp.Models;
using Microsoft.EntityFrameworkCore;
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
                User useless = new User { Name = "lazyman" };
                db.Users.AddRange(nurs, aman, sezim, unknown, useless);
                db.SaveChanges();

                var users = db.Users
                    .Include(u => u.Company)
                    .ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }

                var companies = db.Companies
                    .Include(u => u.Users)
                    .ToList();
                foreach(var company in companies)
                {
                    Console.WriteLine($"Company: {company.Name}");
                    foreach(var user in company.Users)
                    {
                        Console.WriteLine(user.Name);
                    }
                }
            }
        }
    }
}
