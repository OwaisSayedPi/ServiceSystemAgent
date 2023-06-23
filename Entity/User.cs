using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Token { get; set; }
        public StatusTypes Status { get; set; }
        public int ServiceID { get; set; }
        public int CounterID { get; set; }
        public int AgentID { get; set; }
        public DateTime ResolvedTime { get; set; }
    }
    public enum StatusTypes
    {
        Waiting = 1,
        Active = 2,
        Resolved = 3,
    }
}
