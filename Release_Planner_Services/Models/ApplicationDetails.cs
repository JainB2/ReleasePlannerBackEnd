using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Release_Planner_Services.Models
{
    public class ApplicationDetails
    {
        [Key]
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        [ForeignKey("LOB")]
        public int LobId { get; set; }

        public  DateTime InsertDateStamp { get; set; }

        public DateTime UpdateDateStamp { get; set; }
        public char FlgActive { get; set; }
    }
}
