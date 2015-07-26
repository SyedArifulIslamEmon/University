using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Univercity_Project.Models
{
    public class Employment_Status
    {
        public int ID { get; set; }

        public string Status { get; set; }

        public string Employment_Type { get; set; }

        //inja ...tu in... to in ke dg nemikhad dasti bezani....midunam.....aval
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
