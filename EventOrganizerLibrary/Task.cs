using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public class Task
    {
        public string TaskName { get; set; }
        public List<Person> AssignedPersons { get; set; } = new List<Person>();
        public List<Team> AssignedTeams { get; set; } = new List<Team>();
    }
}
