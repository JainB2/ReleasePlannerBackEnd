using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Release_Planner_Services.Models;


namespace Release_Planner_Services.DBContext
{
    public class PlanContext:DbContext
    {
        public PlanContext(DbContextOptions<PlanContext> options):base(options)
        {
                
        }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<LOB> Lob { get; set; }
        public DbSet<MasterPlanTasks> MasterPlanTasks { get; set; }
        public DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public DbSet<MasterPlanTrnTasks> MasterPlanTrnTasks { get; set; }
    }
}
