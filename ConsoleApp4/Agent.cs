using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace c__SQL.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int MissionsCompleted { get; set; }


        public Agent(int id, string codeName, string realName, string location, string status, int missionsCompleted)
        {

            Id = id;
            CodeName = codeName;
            RealName = realName;
            Location = location;
            Status = status;
            MissionsCompleted = missionsCompleted;
        }
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"CodeName: {CodeName}\n" +
                $"RealName: {RealName}\n" +
                $"Location: {Location}\n" +
                $"Status: {Status}\n" +
                $"MissionComplited: {MissionsCompleted}";
        }

    }
}
