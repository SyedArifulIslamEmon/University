using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models
{
    public class Marriage_Status
    {
        public int ID { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
