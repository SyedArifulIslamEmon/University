using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.ViewModels
{
    public class Login_ViewModel
    {
        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "شماره پرسنلی")]
        public string Employment_Number { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "به خاطر سپردن؟")]
        public bool RememberMe = false;     
    }
}
