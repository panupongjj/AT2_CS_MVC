using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AT2_CS_MVC.Models
{
    public class Applicant
    {
        [Key]
        public int AId { get; set; }
        
        [Display(Name = "Name")]
        public string name { get; set; }
        
        [Display(Name = "Date of birth")]
        public DateTime dob { get; set; }
        
        [Display(Name = "Qualification")]
        public string qualification { get; set; }
       
        
        [Display(Name = "GPA")]
        public double gpa { get; set; }
        
        [Display(Name = "University")]
        public string university { get; set; }


        public List<SelectListItem> ListQualification = new List<SelectListItem>();
        //[Display(Name = "Heading")]
        //[Required(ErrorMessage = "Please give the Title")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "SSSSSSSSSSSSSSSSSSSS")]
    }

}
