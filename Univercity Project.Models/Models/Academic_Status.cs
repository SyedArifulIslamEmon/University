using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Univercity_Project.Models
{
    public class Academic_Status
    {
        public int ID { get; set; }

        public string Degree { get; set; }

        public string Major { get; set; }

        public string Branch { get; set; }

        public DateTime Date_OF_Recieving_Degree { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
