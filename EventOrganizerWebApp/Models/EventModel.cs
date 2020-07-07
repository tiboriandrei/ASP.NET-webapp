using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizerWebApp
{
    public class EventModel
    {
        [Required(ErrorMessage = "Introduceti un nume pentru eveniment.")]
        [Display(Name = "Numele evenimentului")]
        public string EventName { get; set; }

        [Display(Name = "Info")]
        public string EventDescription { get; set; }

        [Display(Name = "Data inceperii")]
        [Required(ErrorMessage = "Introduceti data de start.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data incheierii")]
        [Required(ErrorMessage = "Introduceti data de sfarsit.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //[Display(Name = "Invita persoane")]
        //[DataType(DataType.EmailAddress)]
        //public string Emails { get; set; }

    }
}