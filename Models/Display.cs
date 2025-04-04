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
        [Range(3.0, 4.0, ErrorMessage = "The GPA must be between 3.0 and 4.0")]
        [Required(ErrorMessage = "GPA is required.")]
        public double gpa { get; set; }

        [Display(Name = "University")]
        public string university { get; set; }

        //[RequiredListValidation(ErrorMessage = "At least one qualification is required.")]
        public List<SelectListItem> ListQualification { get; set; } = new List<SelectListItem>();

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualification is required.")]
        public string? Qname { get; set; }

    }

    //public class RequiredListValidation : ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        if (value is List<SelectListItem> list)
    //        {
    //            return list != null && list.Count > 0;
    //        }
    //        return false;
    //    }
    //}
}
