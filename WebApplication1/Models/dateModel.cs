using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DateModel
    {
       
        [Display(Name="Full Name")]
        [Required(ErrorMessage = "You Need to enter your Full Name")]
        public string Name { get; set; }
        public string Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/M/yy}")]
        public DateTime DateOfBirth { get; set; }

        public string Horoscope { get; set; }

        public string prediction { get; set; }
    }
}