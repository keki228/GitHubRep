using System;
using System.Collections.Generic;
using System.Reflection;
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
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAge: {Age}";
        }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
