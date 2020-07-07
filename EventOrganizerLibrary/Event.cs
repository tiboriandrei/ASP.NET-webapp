using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public class Event
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Team> AssignedTeams { get; set; } = new List<Team>();
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
