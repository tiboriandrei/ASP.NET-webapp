using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public class Team
    {
        public List<Person> TeamMembers { get; set; } = new List<Person>();
        public string TeamName { get; set; }
    }
}
