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
                        AddUser();
                        break;
                    case 2:
                        ShowUsers();
                        break;
                    case 3:
                        EditUser();
                        break;
                    case 4:
                        RemoveUser();
                        break;
                    default:
                        break;
                }
            }           
        }
        public static void AddUser()
        {
            using (AppContext db = new AppContext())
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
                Console.WriteLine("Enter pos: ");
                string pos = Console.ReadLine();
                var user = new User { Name = name, Age = age, Position = pos };
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("User has been successfully saved.");
            }
        }
        public static void ShowUsers()
        {
            using (AppContext db = new AppContext())
            {
                var users = db.Users.ToList();
                foreach(var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }
        public static void EditUser()
        {
            using (AppContext db = new AppContext())
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

                    Console.WriteLine("Enter new pos: ");
                    string pos = Console.ReadLine();
                    user.Position = pos;

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
        public static void RemoveUser()
        {
            using(AppContext db = new AppContext())
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
