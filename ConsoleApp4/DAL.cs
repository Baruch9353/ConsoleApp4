
using c__SQL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace c__SQL.DAL
{
    internal class DAL
    {
        Agent Agent;
        private string connStr = "server=127.0.0.1;user=root;password=;database=agents";
        private MySqlConnection _conn;

        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                Console.WriteLine("Connection successful.");
            }

            return _conn;
        }

        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }

        public DAL()
        {
            try
            {
                openConnection();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }

        public List<Agent> GetAgents(string query = "SELECT * FROM agents")
        {
            List<Agent> agents = new List<Agent>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string odeName = reader.GetString("odeName");
                    string realName = reader.GetString("realName");
                    string location = reader.GetString("location");
                    string status = reader.GetString("status");
                    int missionsCompleted = reader.GetInt32("missionsCompleted");
                    Agent age = new Agent(id, odeName, realName, location, status, missionsCompleted);
                    agents.Add(age);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error while fetching agents: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching agents: {ex.Message}");
            }

            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }

            return agents;
        }

        public void printAgentList(List<Agent> agents)
        {
            foreach (Agent agent in agents)
            {
                Console.WriteLine(agent);
            }
        }
        public void AddAgent(Agent agent)
        {
            try
            {
                openConnection();
                string query = "INSERT INTO agents (codeName, realName, location, status, missionsCompleted) VALUES ('"
                    + agent.CodeName + "', '"
                    + agent.RealName + "', '"
                    + agent.Location + "', '"
                    + agent.Status + "', "
                    + agent.MissionsCompleted + ")";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding agent: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            try
            {
                openConnection();
                string query = "UPDATE agents SET location = '" + newLocation + "' WHERE id = " + agentId;
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating location: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public void DeleteAgent(int agentId)
        {
            try
            {
                openConnection();
                string query = "DELETE FROM agents WHERE id = " + agentId;
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting agent: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }


    }
}
