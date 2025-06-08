using System;
using System.Collections.Generic;

using c__SQL.DAL;

using MySql.Data.MySqlClient;


namespace c__SQL.DAL
{

    internal class Program
    {
        static void Main()
        {
            DAL dal = new DAL();
            dal.GetAgents();
        }
    }
}
