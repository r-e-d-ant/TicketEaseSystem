using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TicketEaseSystem
{
    class appConnection
    {
        public static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["stringCon"].ConnectionString;
        }
    }
}
