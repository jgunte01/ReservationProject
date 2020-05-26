using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReservationProject.UI.MVC.Models
{
    public class ContactViewModel
    {
       
            
            [Required(ErrorMessage = "*You must provide a Name.")]
            [Display(Name = "Your Name")]
            public string Name { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

        [Required(ErrorMessage = "*You must provide a Subject.")]
        public string Subject { get; set; }

            [Required(ErrorMessage = "*You must provide a message.")]
            [UIHint("MultilineText")]
            public string Message { get; set; }
            
        


    }
}