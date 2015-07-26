 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Univercity_Project.Models.Models
{
    public class War_Record
    {
        public int ID { get; set; }

        public bool Military_Record { get; set; }

        public int? Disable_Percentage { get; set; }
       
        public DateTime? Date_Captured { get; set; }

        public DateTime? Released { get; set; }

        public bool? Desendents_Of_Martyr { get; set; }

        public DateTime? Date_Start_Serving { get; set; }

        public DateTime? Date_Finish_Serving { get; set; }      

        public virtual Employee Employee { get; set; }
    }
}
