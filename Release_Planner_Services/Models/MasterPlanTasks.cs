using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class MasterPlanTasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string FlgActive { get; set; }
        public DateTime CratedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
