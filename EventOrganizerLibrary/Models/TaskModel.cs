using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizerLibrary.Models
{
    public class TaskModel
    {
        public string linkEventId { get; set; }

        public string TaskId { get; set; }
        
        public string TaskName { get; set; }
        
        public string TaskDescription { get; set; }

        public DateTime Deadline { get; set; }
    }
}
