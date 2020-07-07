using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public class SqlConnector : IDataConnection
    {
        public Person CreatePerson(Person person)
        {
            person.id = 1;

            return person;
        }
    }
}
