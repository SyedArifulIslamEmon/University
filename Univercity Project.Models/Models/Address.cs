using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Univercity_Project.Models
{
    public class Address
    {        
        public int ID { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string First_Street { get; set; }

        public string Seconde_Street { get; set; }

        public string Avenue { get; set; }

        public string Block_Number { get; set; }
       
        public int House_Number { get; set; }
       
        public string Post_Code { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
