using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDModalMVC.Models
{
    public class Student
    {
        [Key]
        public int StudenId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

    }
}