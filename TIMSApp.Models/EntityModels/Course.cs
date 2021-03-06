﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TIMSApp.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Outline { get; set; }
        [Required]
        [Display(Name="Course Fee")]
        public decimal Fee { get; set; }
        [Required]
        public int Duration { get; set; } 
    }
}
