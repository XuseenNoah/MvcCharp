using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCsharp.ViewModels
{
    public class Persons
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}