using Release_Planner_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Repository
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetPlans();
        int InsertPlan(int applicationId, int LobId, DateTime ProdReleaseDate);
        IEnumerable<ApplicationDetails> GetApplicationName(string lobId);
        string GetApplicationName_AppId(int appId);
        IEnumerable<MasterPlanTasks> GetTask();
        IEnumerable<LOB> GetLob();
        IEnumerable<Plan> GetPlans_Date(DateTime date);
        IEnumerable<Plan> GetPlans_LobId(int LobId);
        IEnumerable<Plan> FilterAdvance(int lobId, int appId, string date);
        IEnumerable<Plan> GetPlans_PlanId(int planId);
        int EditPlan(Plan plan, int planId);
        string GetLob_LobId(int LobId);
        string CreateMasterPlan(int planId, int taskId, DateTime startTime, int Duration,string Remarks);
        void Delete(int PlanId);
        int DeleteTask(int PlanId,int taskId);
        List<PlanViewModel> FetchTaskDetails_PlanId(List<Plan> plan);

        List<MasterPlanReport> FetchReport(List<Plan> plan);
        List<PlanViewModel> FetchTaskDetails_PlanId_LastTask(int planId);

    }
}
