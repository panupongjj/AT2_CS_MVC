using System.ComponentModel.DataAnnotations;

namespace AT2_CS_MVC.Models
{
    public class Qualification
    {

        [Key]
        public int QId { get; set; }

        public string Qname { get; set; }

    }
}
