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
        [Required,StringLength(10,ErrorMessage ="Waxad galisay way ka badan tahay 10")]
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public IEnumerable<ValidationResult> validations(ValidationContext validationContext)
        {
            if (Image != null)
            {
                if (Image.ContentType.Equals("Image/jpeg"))
                {
                    yield return new ValidationResult("Only jpg files allowed", new string[] { "Image" });
                }
                if(Image.ContentLength >= (4096 * 4096))
                {
                    yield return new ValidationResult("Signature must be less than 1mb", new List<string> { "Image" });
                }
            }
        }
    }
}