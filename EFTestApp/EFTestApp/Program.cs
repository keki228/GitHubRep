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
                Position manager = new Position { Name = "Manager" };
                Position basic = new Position { Name = "Basic" };
                Position developer = new Position { Name = "Developer" };
                db.Positions.AddRange(manager, basic, developer);

                City bish = new City { Name = "Bishkek" };
                City osh = new City { Name = "Osh" };
                City moscow = new City { Name = "Moscow" };
                db.Cities.AddRange(bish, osh, moscow);

                Country rus = new Country { Name = "Russia", Capital = moscow };
                Country kyr = new Country { Name = "Kyrgyzstan", Capital = bish };
                db.AddRange(rus, kyr);

                Company ts = new Company { Name = "TimelySoft", Country = kyr };
                Company google = new Company { Name = "Google", Country = rus };
                db.Companies.AddRange(ts, google);
                db.SaveChanges();

                User nurs = new User { Name = "Nursultan", Company = ts, Position = basic };
                User aman = new User { Name = "Amangeldi", Company = ts, Position = developer };
                User sezim = new User { Name = "Sezim", Company = google, Position = manager };
                User unknown = new User { Name = "X3", Company = google };
                User useless = new User { Name = "lazyman" };
                db.Users.AddRange(nurs, aman, sezim, unknown, useless);
                db.SaveChanges();

                //Eager Loading
                var users = db.Users
                    .Include(u => u.Company)
                        .ThenInclude(comp => comp.Country)
                            .ThenInclude(country => country.Capital)
                    .Include(u => u.Position);
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Position?.Name}");
                    Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country.Name} - {user.Company?.Country.Capital.Name}");
                    Console.WriteLine("--------------------------------");
                }

                //Explicit Loading
                Company company = db.Companies.FirstOrDefault();
                db.Users.Where(u => u.CompanyId == company.Id).Load();
                Console.WriteLine($"Company: {company.Name}");
                foreach(var user in company.Users)
                {
                    Console.WriteLine($"{user.Name} - {user.Position}");
                }

                Company company2 = db.Companies.FirstOrDefault();
                db.Entry(company2).Collection(t => t.Users).Load();
                Console.WriteLine($"Company2: {company2.Name}");
                foreach (var user in company2.Users)
                {
                    Console.WriteLine($"{user.Name} - {user.Position}");
                }

                User uservar = db.Users.FirstOrDefault(x => x.Company!=null);
                db.Entry(uservar).Reference(x => x.Company).Load();
                Console.WriteLine($"{uservar.Name} - {uservar.Company?.Name}");
            }
        }
    }
}
