using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models
{
    public class Phone_Number
    {
        public int ID { get; set; }

        public long Home { get; set; }

        public long? Work { get; set; }

        public long Mobile { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
