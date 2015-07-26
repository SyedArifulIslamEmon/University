using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Univercity_Project.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Univercity_Project.Models
{
    public class Employee : IdentityUser
    {
        
        public string Employment_Number { get; set; }
        
        public string Gender { get; set; }
       
        public int National_ID { get; set; }
       
        public string First_Name { get; set; }
       
        public string Last_Name { get; set; }
       
        public string Father_Name { get; set; }
       
        public string Birth_Place { get; set; }
       
        public DateTime Birth_Date { get; set; }
       
        public string Serial_Alphabetic { get; set; }
       
        public int Serial_Numeric { get; set; }
       
        public int Number_of_People_Under_Support { get; set; }  
        //<----------------------------------------------------------------------------------------------------------->
        
        public virtual Employment_Status Employment_Status { get; set; }
        public int Employment_Status_ID { get; set; }

        public virtual Marriage_Status Marriage_Status { get; set; }
        public int Marriage_Status_ID { get; set; }

        public virtual Job_Status Job_Status { get; set; }

        public virtual Academic_Status Academic_Status { get; set; }

        public virtual Phone_Number Phone_Number { get; set; }

        public virtual War_Record War_Record_Info { get; set; }

        public virtual Address Address { get; set; }

        public virtual Insuarance Insuarance_Info { get; set; }


    }
}
