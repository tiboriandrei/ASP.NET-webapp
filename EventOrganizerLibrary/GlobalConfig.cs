using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // todo - create sql connection
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql); //todo - set this up properly
            }

            if (textFiles)
            {
                TextConnector text = new TextConnector();
                Connections.Add(text);
                // todo - create text connection
            }
        }
    }
}
