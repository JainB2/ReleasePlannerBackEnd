    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Transactions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Release_Planner_Services.Models;
    using Release_Planner_Services.Repository;
    using Release_Planner_Services.DBContext;
using Newtonsoft.Json;

namespace Release_Planner_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {

        private readonly IPlanRepository _planRepository;

        public PlanController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }
        // GET: api/Plan
        [HttpGet("ApplicationName")]
        public IEnumerable<ApplicationDetails> GetApplication(string lobId)
        {
            return _planRepository.GetApplicationName(lobId);
        }

       [HttpGet("lob")]
        public IEnumerable<LOB> GetLob()
        {
            return _planRepository.GetLob();
        }


        [HttpGet("Plans")]
        public IEnumerable<Plan> GetPlans()
        {
            return _planRepository.GetPlans();
        }



        [HttpGet("Plans_LobId")]
        public IEnumerable<Plan> GetPlans_LobId(int LobId)
        {
            return _planRepository.GetPlans_LobId(LobId);
        }

        [HttpGet("Plan_Date")]
       public  IEnumerable<Plan> GetPlans_Date(DateTime date)
        {
            return _planRepository.GetPlans_Date(date);
        }

        [HttpGet("Plan_PlanId")]
        public IEnumerable<Plan> GetPlans_PlanId(int planId)
        {
            return _planRepository.GetPlans_PlanId(planId);
        }
        

        [HttpGet("Tasks")]
        public IEnumerable<MasterPlanTasks> GetMaterPlanTasks()
        {
            return _planRepository.GetTask();
        }

        [HttpGet("AdvanceFilter")]
        public IEnumerable<Plan> GetPlan_Advance(int lobId, int appId, string date)
        {
            return _planRepository.FilterAdvance( lobId,  appId, date);
        }

        [HttpPost("MasterPlan_PlanId")]
        public List<PlanViewModel> FetchTaskDetails_PlanId( [FromBody] List<Plan> plan)
        {
            return _planRepository.FetchTaskDetails_PlanId(plan);
        }


        [HttpPost("MasterPlanReport")]
        public List<MasterPlanReport> FetchMaterPlanReport([FromBody] List<Plan> plan)
        {
            return _planRepository.FetchReport(plan);
        }

        [HttpGet("MaterPlan_PlanId_OrderByTask")]
        public List<PlanViewModel> FetchTaskDetails_PlanId_OrderByTask(int planId)
        {
            return _planRepository.FetchTaskDetails_PlanId_LastTask(planId);
        }

        // PUT: api/Plan/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete")]
        public void Delete(int PlanId)
        {
            _planRepository.Delete(PlanId);
        }

        [HttpDelete("deleteTask")]
        public int DeleteTask(int PlanId,int TaskId)
        {
          return  _planRepository.DeleteTask(PlanId,TaskId);
        }





        [HttpPost("InsertPlan")]
        public int InsertPlan(string applicationId,int LobId,DateTime ProdReleaseDate)
        {
            Plan p = null;
            //  for(int i;i<plan.)
            //int appId = 0;
            int output = 0;
            string [] AppIdArr = applicationId.Split(',');
           
            for (int i = 0; i < AppIdArr.Count()-1; i++)
            {
              output= _planRepository.InsertPlan(Convert.ToInt32(AppIdArr[i]),LobId,ProdReleaseDate);
            }
            return output;
        }
    


    [HttpPut("EditPlan")]
        public int EditPlan(Plan plan, int planId)
        {
            int output = 0;
            if(planId!=0)
            {
             output=  _planRepository.EditPlan(plan, planId);
            }

            return output;
        }

        [HttpPost("InsertMasterPlan")]
        public  string CreateMasterPlan(int planId, int taskId, DateTime startTime, int duration,string remarks)
        {
           
            return _planRepository.CreateMasterPlan(planId, taskId, startTime, duration, remarks);
        }
    }
}
