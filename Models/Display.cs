using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AT2_CS_MVC.Models
{
    public class Display
    {
        public int AId { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime dob { get; set; }

        
        public int QId { get; set; }
        [Display(Name = "GPA")]
        public double gpa { get; set; }

        [Display(Name = "University")]
        public string university { get; set; }

        public List<SelectListItem> ListQualification = new List<SelectListItem>();
        [Display(Name = "Qualification")]
        public string? Qname { get; set; }

    }
}
