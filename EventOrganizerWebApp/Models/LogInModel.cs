using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizerWebApp
{
    public class LogInModel
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Introduceti adresa de email.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Introduceti o parola.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Parola e prea scurta.")]
        public string Password { get; set; }
    }
}