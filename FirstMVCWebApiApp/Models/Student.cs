using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FirstMVCWebApiApp.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "this is required please !")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "maximum five please !")]
        public string  StudentName { get; set; }

        [Range(10, 100, ErrorMessage = "range is (10,100)")]
        public int Age { get; set; }
    }
}