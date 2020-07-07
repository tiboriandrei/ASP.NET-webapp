using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public interface IDataConnection
    {
        Person CreatePerson(Person person);
    }
}
