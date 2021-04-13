using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class PlanViewModel
    {
        public int planId { get; set; }
        public string applicationName { get; set; }
        public string prodReleaseDate { get; set; }
        public string dependencies { get; set; }
       

        public List<task> task { get; set; }
    }
}
