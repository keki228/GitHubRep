using System;
using System.IO;
using System.Linq;
using System.Windows.Markup;
using EFTestApp.Models;
using Microsoft.Extensions.Configuration;
using AppContext = EFTestApp.Models.AppContext;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EFTestApp
{
    public static class Program
    {
        public static void Main()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Environment.CurrentDirectory);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            string choice = "";
            while (choice != "0")
            {
                Console.WriteLine("\n0 - to exit" +
                    "\n1 - to create new user" +
                    "\n2 - to read list of users" +
                    "\n3 - to edit existing user" +
                    "\n4 - to remove user");
                choice = Console.ReadLine();
                if (!int.TryParse(choice, out int ch))
                {
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        AddUser(options);
                        break;
                    case 2:
                        ShowUsers(options);
                        break;
                    case 3:
                        EditUser(options);
                        break;
                    case 4:
                        RemoveUser(options);
                        break;
                    default:
                        break;
                }
            }           
        }
        public static void AddUser(DbContextOptions<AppContext> options)
        {
            using (AppContext db = new AppContext(options))
            {
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                string temp;
                int age;
                do
                {
                    Console.WriteLine("Enter age: ");
                    temp = Console.ReadLine();
                }
                while (!int.TryParse(temp, out age));
                var user = new User { Name = name, Age = age };
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("User has been successfully saved.");
            }
        }
        public static void ShowUsers(DbContextOptions<AppContext> options)
        {
            using (AppContext db = new AppContext(options))
            {
                var users = db.Users.ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Age}");
                }
            }
        }
        public static void EditUser(DbContextOptions<AppContext> options)
        {
            using (AppContext db = new AppContext(options))
            {
                User user = null;
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                user = db.Users.FirstOrDefault(x => x.Name == name);
                if(user!=null)
                {
                    Console.WriteLine("Enter new name: ");
                    name = Console.ReadLine();
                    user.Name = name;

                    string temp;
                    int age;
                    do
                    {
                        Console.WriteLine("Enter age: ");
                        temp = Console.ReadLine();
                    }
                    while (!int.TryParse(temp, out age));
                    user.Age = age;
                    db.Users.Update(user);
                    db.SaveChanges();
                    Console.WriteLine("User was updated.");
                }
                else
                {
                    Console.WriteLine("User does not exist.");
                }
            }
        }
        public static void RemoveUser(DbContextOptions<AppContext> options)
        {
            using(AppContext db = new AppContext(options))
            {
                User user = null;
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                user = db.Users.FirstOrDefault(x => x.Name == name);
                if(user!=null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine("User has been successfully removed.");
                }
                else
                {
                    Console.WriteLine("User was not found.");
                }
            }
        }
    }
}
