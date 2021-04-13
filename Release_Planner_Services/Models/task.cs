using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskStatus { get; set; }
        public int duration { get; set; }
        public int durationTask { get; set; }
        public string startDate { get; set; }
        public string startDateTask { get; set; }
        public string endDate { get; set; }
        public string endDateTask { get; set; }
        public string remarks { get; set; }
    }
}
