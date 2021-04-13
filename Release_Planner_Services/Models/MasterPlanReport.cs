using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class MasterPlanReport
    {
        public string ApplicationName { get; set; }
        public string ProdReleaseDate { get; set; }
        public string Dependencies { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public int DurationTask { get; set; }
        public string StartDateTask { get; set; }
        public string EndDateTask { get; set; }
        public string Remarks { get; set; }
    }
}
