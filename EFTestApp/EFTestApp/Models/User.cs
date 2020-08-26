using System;
using System.Collections.Generic;
using System.Text;

namespace EFTestApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAge: {Age}";
        }
    }
}
