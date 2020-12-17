using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.MVC.UI.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = " * Your Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = " * Please insert your Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = " * This field cannot be left blank")]
        [StringLength(250, ErrorMessage = "Max 250 characters")]
        [UIHint("MultilineText")]
        public string Message { get; set; }


    }
}