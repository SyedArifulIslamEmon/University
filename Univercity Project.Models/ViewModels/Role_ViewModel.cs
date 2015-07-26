using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.ViewModels
{
    public class Role_ViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "نام نقش")]
        public string Name { get; set; }
    }
}
