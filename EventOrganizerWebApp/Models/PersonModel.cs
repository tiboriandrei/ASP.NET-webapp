using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizerWebApp
{
    public class PersonModel
    {
        //[Display(Name = "User ID")]
        //[Range(1000, 9999, ErrorMessage ="ID-ul nu este valid.")]
        //public int PersonID { get; set; }

        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Introduceti numele.")]
        public string FirstName { get; set; }

        [Display(Name = "Preume")]
        [Required(ErrorMessage = "Introduceti prenumele.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Introduceti adresa de email.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "Adresa de email nu se potriveste.")]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "Telefon")]
        //[Required(ErrorMessage = "Introduceti un numar de telefon.")]
        public string CellphoneNumber { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Introduceti o parola.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Parola e prea scurta.")]
        public string Password { get; set; }

        [Display(Name = "Confirmare Parola")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola nu se potriveste.")]
        public string ConfirmPassword { get; set; }
    }
}
