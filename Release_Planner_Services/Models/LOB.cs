using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class LOB
    {   [Key]
        public int LobId { get; set; }
        public string LobName { get; set; }
        public DateTime  CreatedDate { get; set; }
        public char FlgActive { get; set; }
    }
}
