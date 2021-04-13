using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Release_Planner_Services.DBContext;
using Release_Planner_Services.Models;

namespace Release_Planner_Services.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private readonly PlanContext _dbContext;

        public PlanRepository(PlanContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Plan> GetPlans()
        {
            var dtPlan = _dbContext.Plan.ToList().OrderBy(x => x.ProdReleaseDate);

            IEnumerable<Plan> dtPlanFilter = from dt1 in dtPlan where (dt1.ProdReleaseDate.Date >= DateTime.Now) orderby dt1.ProdReleaseDate ascending select dt1;
            return dtPlanFilter.ToList();
        }


        public IEnumerable<LOB> GetLob()
        {
            return _dbContext.Lob.ToList();
        }

        public string GetLob_LobId(int LobId)
        {
            IEnumerable<LOB> appList = null;
            string lobName = string.Empty;
            try
            {
                if (LobId != 0)
                {
                    appList = _dbContext.Lob.Where(x => x.LobId == LobId);
                }

                foreach (var v in appList)
                {
                    lobName = v.LobName;
                }
            }
            catch (Exception ex)
            {

            }
            return lobName;
        }


        public IEnumerable<ApplicationDetails> GetApplicationName(string strlobId)
        {
            int lobId = Convert.ToInt32(strlobId);
            IEnumerable<ApplicationDetails> appList = null;
            try
            {
                if (lobId == -1)
                {
                    appList = _dbContext.ApplicationDetails.ToList();
                }
                else
                {
                    appList = _dbContext.ApplicationDetails.Where(x => x.LobId == lobId);
                }
            }
            catch (Exception ex)
            {

            }
            return appList;
        }

        public IEnumerable<MasterPlanTasks> GetTask()
        {
            IEnumerable<MasterPlanTasks> listTask = null;

            try
            {
                listTask = _dbContext.MasterPlanTasks.ToList();
            }
            catch (Exception ex)
            {

            }

            return listTask;
        }
        public string GetApplicationName_AppId(int appId)
        {
            //int lobId = Convert.ToInt32(strlobId);
            IEnumerable<ApplicationDetails> appList = null;
            string appName = string.Empty;
            try
            {
                if (appId != 0)
                {
                    appList = _dbContext.ApplicationDetails.Where(x => x.ApplicationID == appId);
                }

                foreach (var v in appList)
                {
                    appName = v.ApplicationName;
                }
            }
            catch (Exception ex)
            {

            }
            return appName;
        }

        public List<PlanViewModel> FetchTaskDetails_PlanId(List<Plan> plan1)
        {
            IEnumerable<MasterPlanTrnTasks> taskList = null;
            IEnumerable<Plan> plan = null;
            PlanViewModel vm = null;
            List<PlanViewModel> pvm =new List<PlanViewModel>();
            //string taskName = string.Empty;
            try
            {
                if (plan1 != null)
                {
                    for (int i = 0; i < plan1.Count; i++)
                    {

                        plan = GetPlans_PlanId(plan1[i].PlanId);
                        taskList = _dbContext.MasterPlanTrnTasks.Where(x => x.PlanId == plan1[i].PlanId);
                        //PlanViewModel vm = new PlanViewModel();

                        //orderby t.EndDateTime descending
                        var ViewModel = from p in plan
                                        join t in taskList on p.PlanId equals t.PlanId
                                         into data
                                        from d in data.DefaultIfEmpty()
                                        select new
                                        {
                                            planId = p.PlanId,
                                            applicationName=p.ApplicationName,
                                            dependencies=p.Dependencies,
                                            prodReleaseDate=p.ProdReleaseDate,
                                            startDate = p.StartDateTime,
                                            endTime = p.EndDateTime,
                                            duration = p.Duration,
                                            taskId = d == null ? 0 : d.TaskId,
                                            startTimeTask = d==null?"No Record found" :Convert.ToString( d.StartDateTime),
                                            endTimeTask = d == null ? "No Record found" : Convert.ToString(d.EndDateTime),
                                            durationTask = d == null ? 0 : d.Duration,
                                            
                                            taskName = d == null ? "No Record found" : d.TaskName,
                                            taskStatus = d == null ? "No Record found" : d.TaskValue,
                                            remarks = d == null ? "No Record found" : d.Remarks



                                        };


                        vm = new PlanViewModel();
                        task task = null;



                        vm.task = new List<task>();

                        foreach (var t in ViewModel)
                        {


                            vm.planId = t.planId;
                            vm.applicationName = t.applicationName;
                            vm.dependencies = t.dependencies;
                           // vm.prodReleaseDate = Convert.ToString(t.prodReleaseDate);
                            if(t.prodReleaseDate==DateTime.MinValue)
                            {
                                vm.prodReleaseDate = "";
                            }
                            else
                            {
                                vm.prodReleaseDate = Convert.ToString(t.prodReleaseDate);
                            }
                            
                            foreach (var v in ViewModel)
                            {
                                task = new task();

                                if (v.startDate == DateTime.MinValue)
                                {
                                    task.startDate = "";
                                }
                                else
                                {
                                    task.startDate = Convert.ToString(v.startDate);
                                }

                                if (v.endTime == DateTime.MinValue)
                                {
                                    task.endDate = "";
                                }
                                else
                                {
                                    task.endDate = Convert.ToString(v.endTime);
                                }

                                if ( v.startTimeTask== "")
                                {
                                    task.startDateTask = "";
                                }
                                else
                                {
                                    task.startDateTask = Convert.ToString(v.startTimeTask);
                                }



                                if (v.endTimeTask == "")
                                {
                                    task.endDateTask = "";
                                }
                                else
                                {
                                    task.endDateTask = Convert.ToString(v.endTimeTask);
                                }


                                
                                task.duration = v.duration;
                                task.durationTask = v.durationTask;
                                task.taskId = v.taskId;
                                task.taskName = v.taskName;
                                task.taskStatus = v.taskStatus;
                                task.remarks = v.remarks;
                                vm.task.Add(task);

                            }

                            pvm.Add(vm);

                            break;
                        }
                    }

                }

               
            }
             catch(Exception ex)
                {
                    throw new NotImplementedException();
               }
            return pvm;
        }



        public List<MasterPlanReport> FetchReport(List<Plan> plan1)
        {
            IEnumerable<MasterPlanTrnTasks> taskList = null;
            IEnumerable<Plan> plan = null;
            MasterPlanReport vm = null;
            List<MasterPlanReport> pvm = new List<MasterPlanReport>();
            //string taskName = string.Empty;
            try
            {
                if (plan1 != null)
                {
                    for (int i = 0; i < plan1.Count; i++)
                    {

                        plan = GetPlans_PlanId(plan1[i].PlanId);
                        taskList = _dbContext.MasterPlanTrnTasks.Where(x => x.PlanId == plan1[i].PlanId);
                        //PlanViewModel vm = new PlanViewModel();

                        //orderby t.EndDateTime descending
                        var ViewModel = from p in plan
                                        join t in taskList on p.PlanId equals t.PlanId
                                         into data
                                        from d in data.DefaultIfEmpty()
                                        select new
                                        {
                                            planId = p.PlanId,
                                            applicationName = p.ApplicationName,
                                            dependencies = p.Dependencies,
                                            prodReleaseDate = p.ProdReleaseDate,
                                            startDate = p.StartDateTime,
                                            endTime = p.EndDateTime,
                                            duration = p.Duration,
                                            taskId = d == null ? 0 : d.TaskId,
                                            startTimeTask = d == null ? "" : Convert.ToString(d.StartDateTime),
                                            endTimeTask = d == null ? "" : Convert.ToString(d.EndDateTime),
                                            durationTask = d == null ? 0 : d.Duration,

                                            taskName = d == null ? "" : d.TaskName,
                                            taskStatus = d == null ? "" : d.TaskValue,
                                            remarks = d == null ? "" : d.Remarks
                                           };


                      
                       // task task = null;



                        //vm.task = new List<task>();

                        foreach (var t in ViewModel)
                        {
                            vm = new MasterPlanReport();

                            //vm.planId = t.planId;
                            vm.ApplicationName = t.applicationName;
                            vm.Dependencies = t.dependencies;
                            vm.TaskName = t.taskName;
                            vm.TaskStatus = t.taskStatus;
                            // vm.prodReleaseDate = Convert.ToString(t.prodReleaseDate);
                            vm.DurationTask = t.durationTask;
                            if (t.prodReleaseDate == DateTime.MinValue)
                            {
                                vm.ProdReleaseDate = "";
                            }
                            else
                            {
                                vm.ProdReleaseDate = Convert.ToString(t.prodReleaseDate);
                            }

                            
                                //task = new task();

                                if (t.startTimeTask =="")
                                {
                                    vm.StartDateTask = "";
                                }
                                else
                                {
                                    vm.StartDateTask = Convert.ToString(t.startTimeTask);
                                }

                                if (t.endTimeTask == "")
                                {
                                    vm.EndDateTask = "";
                                }
                                else
                                {
                                    vm.EndDateTask = Convert.ToString(t.endTimeTask);
                                }

                               
                                vm.Remarks = t.remarks;
                              

                            

                            pvm.Add(vm);

                           // break;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            return pvm;
        }








        public List<PlanViewModel> FetchTaskDetails_PlanId_LastTask(int planId)
        {
            IEnumerable<MasterPlanTrnTasks> taskList = null;
            IEnumerable<Plan> plan = null;
            PlanViewModel vm = null;
            List<PlanViewModel> pvm = new List<PlanViewModel>();
            //string taskName = string.Empty;
            try
            {
                if (planId != 0)
                {
                    plan = GetPlans_PlanId(planId);
                    taskList = _dbContext.MasterPlanTrnTasks.Where(x => x.PlanId == planId);
                    //PlanViewModel vm = new PlanViewModel();

                    var ViewModel = from p in plan
                                    join t in taskList on p.PlanId equals t.PlanId
                                     into data
                                    from d in data.DefaultIfEmpty()
                                    orderby d.EndDateTime descending
                                    select new
                                    {
                                        planId = p.PlanId,
                                        applicationName = p.ApplicationName,
                                        dependencies = p.Dependencies,
                                        prodReleaseDate = p.ProdReleaseDate,
                                        startDate = p.StartDateTime,
                                        endTime = p.EndDateTime,
                                        duration = p.Duration,
                                        taskId = d == null ? 0 : d.TaskId,
                                        startTimeTask = d == null ? "No Record found" : Convert.ToString(d.StartDateTime),
                                        endTimeTask = d == null ? "No Record found" : Convert.ToString(d.EndDateTime),
                                        durationTask = d == null ? 0 : d.Duration,

                                        taskName = d == null ? "No Record found" : d.TaskName,
                                        taskStatus = d == null ? "No Record found" : d.TaskValue,
                                        remarks = d == null ? "No Record found" : d.Remarks



                                    };

                    vm = new PlanViewModel();
                    task task = null;



                    vm.task = new List<task>();
                    if(ViewModel.Count()>0)
                    {
                        foreach (var t in ViewModel)
                        {


                            vm.planId = t.planId;
                            vm.applicationName = t.applicationName;
                            vm.dependencies = t.dependencies;
                            // vm.prodReleaseDate = Convert.ToString(t.prodReleaseDate);
                            if (t.prodReleaseDate == DateTime.MinValue)
                            {
                                vm.prodReleaseDate = "";
                            }
                            else
                            {
                                vm.prodReleaseDate = Convert.ToString(t.prodReleaseDate);
                            }

                            foreach (var v in ViewModel)
                            {
                                task = new task();

                                if (v.startDate == DateTime.MinValue)
                                {
                                    task.startDate = "";
                                }
                                else
                                {
                                    task.startDate = Convert.ToString(v.startDate);
                                }

                                if (v.endTime == DateTime.MinValue)
                                {
                                    task.endDate = "";
                                }
                                else
                                {
                                    task.endDate = Convert.ToString(v.endTime);
                                }

                                if (v.startTimeTask == "")
                                {
                                    task.startDateTask = "";

                                }
                                else
                                {
                                    task.startDateTask = Convert.ToString(v.startTimeTask);
                                }



                                if (v.endTimeTask == "")
                                {
                                    task.endDateTask = "";
                                }
                                else
                                {
                                    task.endDateTask = Convert.ToString(v.endTimeTask);
                                }



                                task.duration = v.duration;
                                task.durationTask = v.durationTask;
                                task.taskId = v.taskId;
                                task.taskName = v.taskName;
                                task.taskStatus = v.taskStatus;
                                task.remarks = v.remarks;
                                vm.task.Add(task);

                            }

                            pvm.Add(vm);

                            break;
                        }
                    }
                    
                }


            }
            catch (Exception ex)
            {
               
            }
            return pvm;
        }


        public string GetTaskName_TaskId(int taskId)
        {
            //int lobId = Convert.ToInt32(strlobId);
            IEnumerable<MasterPlanTasks> taskList = null;
            string taskName = string.Empty;
            try
            {
                if (taskId != 0)
                {
                    taskList = _dbContext.MasterPlanTasks.Where(x => x.TaskId == taskId);
                }

                foreach (var v in taskList)
                {
                    taskName = v.TaskName;
                }
            }
            catch (Exception ex)
            {

            }
            return taskName;
        }

        public IEnumerable<Plan> GetPlans_Date(DateTime date)
        {

            IEnumerable<Plan> dtPlan = null;
            DateTime startDate = date;
            DateTime endDate = date.AddDays(2);

            dtPlan = _dbContext.Plan.ToList();

            IEnumerable<Plan> dtPlanFilter = from dt1 in dtPlan where (dt1.ProdReleaseDate.Date >= startDate.Date && dt1.ProdReleaseDate.Date <= endDate) orderby dt1.ProdReleaseDate ascending select dt1;
            return dtPlanFilter.ToList();
        }

        public IEnumerable<Plan> GetPlans_DateCombine(DateTime date, IEnumerable<Plan> dtPlan)
        {


            DateTime startDate = date;
            DateTime endDate = date.AddDays(2);



            IEnumerable<Plan> dtPlanFilter = from dt1 in dtPlan where (dt1.ProdReleaseDate.Date >= startDate.Date && dt1.ProdReleaseDate.Date <= endDate) orderby dt1.ProdReleaseDate ascending select dt1;
            return dtPlanFilter.ToList();
        }


        public IEnumerable<Plan> GetPlans_LobId(int LobId)
        {

            IEnumerable<Plan> dtPlan = null;


            dtPlan = _dbContext.Plan.ToList();

            IEnumerable<Plan> dtPlanFilter = dtPlan.Where(x => x.LobId == LobId).OrderBy(x => x.ProdReleaseDate);
            return dtPlanFilter.ToList();
        }

        public IEnumerable<Plan> GetPlans_PlanId(int planId)
        {
            IEnumerable<Plan> dtPlan = null;
            return dtPlan = _dbContext.Plan.Where(x => x.PlanId == planId).OrderBy(x => x.ProdReleaseDate);
        }


        public IEnumerable<Plan> FilterAdvance(int lobId, int appId, string date)
        {
            DateTime dt = DateTime.MinValue;
            if (date != null && date != "null")
            {
                dt = Convert.ToDateTime(date);
            }

            IEnumerable<Plan> planList = null;
            if (lobId == 0 && appId == 0 && (date == null ||  date == "null"))
            {
                planList = GetPlans();
            }
            else if (lobId != 0 && appId == 0 && (date == null || date == "null"))
            {
                planList = GetPlans_LobId(lobId);
            }
            else if (lobId == 0 && appId != 0 && (date == null || date == "null"))
            {
                planList = _dbContext.Plan.Where(x => x.ApplicationId == appId);
            }
            else if (lobId == 0 && appId == 0 && date != null && date != "null")
            {
                planList = GetPlans_Date(dt);

            }
            else if (lobId != 0 && appId != 0 && (date == null ||  date == "null"))
            {
                planList = _dbContext.Plan.Where(x => x.ApplicationId == appId);
            }
            else if (lobId != 0 && appId == 0 && date != null && date != "null")
            {
                planList = GetPlans_LobId(lobId);
                planList = GetPlans_DateCombine(Convert.ToDateTime(date), planList);
            }
            else if (lobId == 0 && appId != 0 && date != null && date != "null")
            {
                planList = _dbContext.Plan.Where(x => x.ApplicationId == appId);
                planList = GetPlans_DateCombine(Convert.ToDateTime(date), planList);
            }
            else if (lobId != 0 && appId != 0 && date != null && date != "null")
            {
                planList = _dbContext.Plan.Where(x => x.ApplicationId == appId);
                planList = GetPlans_DateCombine(Convert.ToDateTime(date), planList);
            }

            return planList;
        }


        public int InsertPlan(int ApplicationId, int LobId, DateTime ProdReleaseDate)
        {
            Plan plan1 = null;
            int output = 0;
            //IPlanRepository _planRepository;
            try
            {
                using (var scope = new TransactionScope())
                {

                    plan1 = new Plan();
                    plan1.ApplicationId = ApplicationId;
                    plan1.LobId = LobId;
                    plan1.LobName = GetLob_LobId(LobId);

                    plan1.ApplicationName = GetApplicationName_AppId(ApplicationId);
                    plan1.Environment = "Production";
                    plan1.ProdReleaseDate = ProdReleaseDate.Date;
                    plan1.PTSTGBaseline = ProdReleaseDate.AddDays(-7).Date;
                    // plan1.ActualTimelinesforStageplanFinalization = plan.ProdReleaseDate.AddDays(-5).Date;
                    //  plan1.ActualTimelinesforStageplanFinalization = plan.ProdReleaseDate.AddDays(-4);
                    plan1.TimelineForStagePlanMock = ProdReleaseDate.AddDays(-4).Date;
                    plan1.TimelinesStgPlanFinalizationWithWalkthrough = ProdReleaseDate.AddDays(-5).Date;
                    plan1.TimelinesForPRODUCRPlanBaseline = ProdReleaseDate.AddDays(-4).Date;
                    plan1.TimelinesForPRODUCRPlanFinalizationWithWalkthroughAndFreeze = ProdReleaseDate.AddDays(-2).Date;
                    plan1.CreatedTimeStamp = DateTime.Now.Date;
                    plan1.UpdateTimeStamp = DateTime.Now.Date;
                    // _planRepository.InsertPlan(plan1);
                    _dbContext.Add(plan1);
                    _dbContext.SaveChanges();
                    scope.Complete();
                    output = 1;

                }
            }
            catch(Exception ex)
            {
               
            }
            return output;
          
        }
        public void Delete(int PlanId)
        {

            var plan = _dbContext.Plan.FirstOrDefault(x => x.PlanId == PlanId);
            _dbContext.Remove(plan);
            _dbContext.SaveChanges();

        }

        public int DeleteTask(int PlanId, int TaskId)
        {
            int outPut = 0;
            try
            {
                var plan = _dbContext.MasterPlanTrnTasks.FirstOrDefault(x => x.PlanId == PlanId && x.TaskId==TaskId);
                _dbContext.Remove(plan);
                _dbContext.SaveChanges();

                outPut = 1;
            }
            catch(Exception ex)
            {
                
            }
            return outPut;
           

        }


        public int EditPlan(Plan plan, int planId)
        {
            int output = 0;

            try
            {
                var planInDB = _dbContext.Plan.Single(x => x.PlanId == planId);
                planInDB.ATSTGBaseline = plan.ATSTGBaseline.ToLocalTime();
                planInDB.ActualTimelinesforStageplanFinalization = plan.ActualTimelinesforStageplanFinalization.ToLocalTime();
                planInDB.ActualTimelinesForStagePlanMock = plan.ActualTimelinesForStagePlanMock.ToLocalTime();
                planInDB.UpdateTimeStamp = DateTime.Now.Date;
                planInDB.Dependencies = plan.Dependencies;
                planInDB.SPOC = plan.SPOC;
                planInDB.Remarks = plan.Remarks;
                planInDB.ServerAccess = plan.ServerAccess;
                planInDB.ProdPlanReceived = plan.ProdPlanReceived;
                planInDB.RITM = plan.RITM;
                // planInDB.stgMockReceived = plan.stgMockReceived;
                //planInDB.ProdPlanReceive = plan.ProdPlanReceive;
                planInDB.stgMockReceived = plan.stgMockReceived;
                planInDB.ProdFollowUpCount = plan.ProdFollowUpCount;
                planInDB.StgfollowUpCount = plan.StgfollowUpCount;
                planInDB.ProdWalkThrough = plan.ProdWalkThrough;

                _dbContext.SaveChanges();
                output = 1;
            }

            catch(Exception ex)
            {
                output = 0;
            }

            return output;

        }
        public void EditPlanForMaster(int planId, DateTime StartDateTime, int Duration)
        {

            var planInDB = _dbContext.Plan.Single(x => x.PlanId == planId);
            planInDB.StartDateTime = StartDateTime;
            planInDB.EndDateTime = StartDateTime.AddMinutes(Duration);
            planInDB.Duration = Duration;

            _dbContext.SaveChanges();

        }
        public string CreateMasterPlan(int planId, int taskId, DateTime startTime, int Duration,string Remarks)
        {
            MasterPlanTrnTasks task = null;
            string output = string.Empty;

            IEnumerable<MasterPlanTrnTasks> MasterPlanInDB = from p in _dbContext.MasterPlanTrnTasks where p.PlanId.Equals(planId)
                                                             && p.TaskId.Equals(taskId) select p;

            var MasterPlanInDB1 = (from p in _dbContext.MasterPlanTrnTasks
                                                             where p.PlanId.Equals(planId) orderby p.EndDateTime descending select p).FirstOrDefault();
            //DateTime dt = DateTime.Now;
            //if (MasterPlanInDB1.EndDateTime != null)
            //{
            //     dt =MasterPlanInDB1.EndDateTime;
            //}
            //else
            //{
            //    dt = startTime;
            //}
                

           // EditPlanForMaster(planId, startTime, Duration);
            if (MasterPlanInDB.Count()==0)

            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        task = new MasterPlanTrnTasks();
                        task.PlanId = planId;
                        task.TaskId = taskId;
                        task.TaskName = GetTaskName_TaskId(taskId);
                        task.StartDateTime = startTime;
                       // task.TaskValue = taskValue;
                        task.EndDateTime = startTime.AddMinutes(Duration);
                        task.Duration = Duration;
                        task.Remarks = Remarks;


                        _dbContext.Add(task);
                        _dbContext.SaveChanges();
                        scope.Complete();
                        output = "1";
                    }
                }
                catch (Exception ex)
                {
                    output = "0";
                }
            }

           else
            {
                
                foreach(var v in MasterPlanInDB)
                {
                    v.StartDateTime = startTime;
                    v.EndDateTime = startTime.AddMinutes(Duration);
                    v.Duration = Duration;
                    v.Remarks = Remarks;
                    //v.TaskValue = taskValue;

                }
                output = "2";
                _dbContext.SaveChanges();
            }
            return output;

        }
    }
}