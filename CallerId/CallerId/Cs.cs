using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallerId
{
    class Cs
    {
       public string My()
        {
            // Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CallerDb;Integrated Security=True;Connect Timeout=30
            string test =
             File.ReadAllText("Conn.txt");
            return test;
        }
    }
}
