using System;
using System.Collections.Generic;

using c__SQL.DAL;
using c__SQL.Models;
using MySql.Data.MySqlClient;


namespace c__SQL.DAL
{

    internal class Program
    {
        static void Main()
        {
            Agent agent = new Agent(3,"a","A","as","bb",4);
            DAL dal = new DAL();
            dal.GetAgents();
            dal.AddAgent(agent);
            dal.UpdateAgentLocation(3,"home");
            dal.DeleteAgent(3);
            dal.printAgentList();
        }
    }

}
