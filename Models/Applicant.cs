using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AT2_CS_MVC.Models
{
    public class Applicant
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }

        public List<SelectListItem> qulification = new List<SelectListItem>();
       
        public float gpa { get; set; }
        public string university { get; set; }

        //[Display(Name = "Heading")]
        //[Required(ErrorMessage = "Please give the Title")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "SSSSSSSSSSSSSSSSSSSS")]

    }
}
