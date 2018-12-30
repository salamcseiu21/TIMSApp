using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TIMSApp.Models.EntityModels
{
  public class Batch
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name= "Total Seats")]
        public int TotalSeats { get; set; }
        [Required]
        [Display(Name = "Registration Start")]
        public DateTime RegistrationStart { get; set; }
        [Required]
        [Display(Name = "Registration End")]
        public DateTime RegistrationEnd { get; set; }
        [Required]
        [Display(Name = "Class Start")]
        public DateTime ClassStart { get; set; }  
    }
}
