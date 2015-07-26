using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Univercity_Project.Models.Config_Classes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Univercity_Project.Models.Models
{
    public class MyDbContext : IdentityDbContext<Employee>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Employee_Config());
            base.OnModelCreating(modelBuilder);
        }
    }
}
