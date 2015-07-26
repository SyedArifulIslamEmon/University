using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Univercity_Project.Models.Models
{
    public class Insuarance
    {
        public int ID { get; set; }

        public string Insuarance_Code { get; set; }

        public string Name_Of_Factory_Request_Insuarance { get; set; }

        public string Code_Of_Factory_Request_Insuarance { get; set; }

        public string Type_Of_Insuarance { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
