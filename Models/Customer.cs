using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Must be at least 4 character long.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select one")]
        public string Gender { get; set; }
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }
}
