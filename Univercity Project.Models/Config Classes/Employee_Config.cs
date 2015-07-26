using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.Config_Classes
{
    class Employee_Config : EntityTypeConfiguration<Employee>
    {
        public Employee_Config()
        {
            //Relations            
            this.HasRequired(m => m.Employment_Status)
                .WithMany(m => m.Employees)
                .HasForeignKey(m => m.Employment_Status_ID)
                .WillCascadeOnDelete();

            this.HasRequired(m => m.Marriage_Status)
                .WithMany(m => m.Employees)
                .HasForeignKey(m => m.Marriage_Status_ID)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.Academic_Status)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.Job_Status)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.Phone_Number)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.War_Record_Info)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.Address)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();

            this.HasOptional(m => m.Insuarance_Info)
                .WithRequired(m => m.Employee)
                .WillCascadeOnDelete();
        }
    }
}
