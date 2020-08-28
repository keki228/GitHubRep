using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

namespace EFTestApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int? CompanyId { get; set; } // foreign key
        public Company Company { get; set; } // navigation property
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAge: {Age}";
        }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<User> Users { get; set; }
    }
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CapitalId { get; set; }
        public City Capital { get; set; }
        public List<Company> Companies { get; set; }

    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
