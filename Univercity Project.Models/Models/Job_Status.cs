using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models
{
    public class Job_Status
    {
        public int ID { get; set; }

        public string Unit { get; set; }

        public string Location { get; set; }

        public string Job_Title { get; set; }

        public string Job_Group { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
