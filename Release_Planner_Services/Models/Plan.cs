using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class Plan
    {   
        [Key]
        public int PlanId { get; set; }
        public int ApplicationId  { get; set; }
        //public string [] applicationId { get; set; }
        public int LobId { get; set; }
        public string LobName { get; set; }

        public string  ApplicationName { get; set; }
        public string  Environment { get; set; }
        public string Status { get; set; }
        public string stgMockReceived { get; set; }
        
        public DateTime ProdReleaseDate { get; set; }
        public string ProdPlanReceived { get; set; }
        public DateTime StgMockPlanReceived { get; set; }
        public DateTime PTSTGBaseline { get; set; }
        public DateTime ATSTGBaseline { get; set; }
        public DateTime TimelinesStgPlanFinalizationWithWalkthrough { get; set; }
        public DateTime ActualTimelinesforStageplanFinalization { get; set; }
        public DateTime TimelineForStagePlanMock { get; set; }
        public DateTime ActualTimelinesForStagePlanMock { get; set; }
        public DateTime TimelinesForPRODUCRPlanBaseline { get; set; }
        public DateTime TimelinesForPRODUCRPlanFinalizationWithWalkthroughAndFreeze { get; set; }
        public int ProdFollowUpCount { get; set; }
        public int StgfollowUpCount { get; set; }

        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdateTimeStamp { get; set; }
        public string ProdWalkThrough { get; set; }
        public string RITM { get; set; }
       // public string ProdPlanReceive { get; set; }
        public string SPOC { get; set; }
        public string ServerAccess { get; set; }
        public string Dependencies { get; set; }
        public string Remarks { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Duration { get; set; }
    }

}
