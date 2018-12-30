using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSApp.Models.EntityModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Outline { get; set; }
        public decimal Fee { get; set; }
        public int Duration { get; set; } 
    }
}
