using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class MasterPlanTrnTasks
    {   [Key]
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskValue { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string AddedBy { get; set; }
        public string  UpdatedBy { get; set; }
        public string Remarks { get; set; }
    }
}
