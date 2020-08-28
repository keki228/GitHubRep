using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFTestApp.Models
{
    [Table("Пользователь")]
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("FullName")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        [NotMapped]
        public string Info { get; set; }
        public int CompanyId { get; set; }
        public Company Manifacturer { get; set; }
        public Passport PassportInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CountryId { get; set; }

        public Country Motherland { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAge: {Age}\nPos: {Position}";
        }
    }

    public class Passport
    {
        public int Id { get; set; }
        public string INN { get; set; }
        public string SerialNumber { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
