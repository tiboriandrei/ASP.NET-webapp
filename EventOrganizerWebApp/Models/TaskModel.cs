using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizerWebApp
{
    public class TaskModel
    {
        public int TaskID { get; set; }

        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Introduceti numele task-ului.")]
        public string TaskName { get; set; }

        [Display(Name = "Descriere")]
        [Required(ErrorMessage = "Introduceti o descriere.")]
        public string TaskDescription { get; set; }

        [Display(Name = "Data limita")]
        [Required(ErrorMessage = "Introduceti data limita.")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
    }
}
