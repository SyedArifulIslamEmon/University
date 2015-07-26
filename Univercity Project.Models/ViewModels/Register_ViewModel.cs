using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.ViewModels
{
    public class Register_ViewModel
    {
        public Register_ViewModel()
        {
            this.Military_Record_Yes = false;
            this.Desendents_Of_Martyr_Yes = false;
        }
        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "شماره پرسنلی")]
        public string Employment_Number { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 کاراکتر داشته باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password", ErrorMessage = "کلمات عبور با هم همخوانی ندارند!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "جنسیت")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کد ملی")]
        public int National_ID { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نام")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نام خانوادگی")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نام پدر")]
        public string Father_Name { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "محل تولد")]
        public string Birth_Place { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date)]
        public DateTime Birth_Date { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "سریال حرفی شناسنامه")]
        public string Serial_Alphabetic { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "سریال عددی شناسنامه")]
        public int Serial_Numeric { get; set; }
       
        //----------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "وضعیت اشتغال")]
        public int Employment_Status { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نوع استخدام")]
        public int Employment_Type { get; set; }

        //---------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "وضعیت تاهل")]
        public int Marriage_Status { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "تعداد افراد تحت تکفل")]
        [Range(0,9999999999)]
        public int Number_of_People_Under_Support { get; set; }

        //-------------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "آخرین مدرک نحصیلی")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "رشته")]
        public string Major { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "گرایش")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [DataType(DataType.Date)]
        [Display(Name = "تاریخ فارغ التحصیلی")]
        public DateTime Date_OF_Recieving_Degree { get; set; }

        //--------------------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "واحد سازمانی")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "محل خدمت")]
        public string Location { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "عنوان  پست")]
        public string Job_Title { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "گروه شغلی")]
        public string Job_Group { get; set; }

        //------------------------------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "تلفن محل سکونت")]
        public long Home { get; set; }

        [Display(Name = "تلفن محل کار")]
        public long? Work { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "تلفن همراه")]
        public long Mobile { get; set; }

        //-----------------------------------------------------------------------------------

        [Display(Name = "دارای سابقه نظامی")]
        public bool Military_Record_Yes { get; set; }

        public bool Military_Record_No { get; set; }

        [Display(Name = "درصد جانبازی")]
        [Range(10,90,ErrorMessage="درصد جانبازی باید عدد صحیحی بین 10 تا 90 باشد!")]
        public int? Disable_Percentage { get; set; }

        [Display(Name = "تاریخ دستگیری")]
        public DateTime? Date_Captured { get; set; }

        [Display(Name = "تاریخ آزادی")]
        public DateTime? Released { get; set; }

        [Display(Name = "فرزند شهید")]
        public bool Desendents_Of_Martyr_Yes { get; set; }

        public bool Desendents_Of_Martyr_No { get; set; }       

        [Display(Name = "تاریخ شروع خدمت")]
        public DateTime? Date_Start_Serving { get; set; }
        
        [Display(Name = "تاریخ پایان خدمت")]
        public DateTime? Date_Finish_Serving { get; set; }
       
        //----------------------------------------------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کد شناسایی بیمه")]
        public string Insuarance_Code { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نام کارگاه بیمه گذار")]
        public string Name_Of_Factory_Request_Insuarance { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کد کارگاه بیمه گذار")]
        public string Code_Of_Factory_Request_Insuarance { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "نوع بیمه")]
        public string Type_Of_Insuarance { get; set; }

        //------------------------------------------------------------------------------------------------------

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "شهر")]
        public string City { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "منطقه")]
        public string District { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "خیابان اصلی")]
        public string First_Street { get; set; }

        [Display(Name = "خیابان فرعی")]
        public string Seconde_Street { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کوچه")]
        public string Avenue { get; set; }

        [Display(Name = "نام/شماره ساختمان")]
        public string Block_Number { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "پلاک")]
        [Range(1,999,ErrorMessage=" شماره پلاک باید عددی صحیح بین 1 تا 999 باشد!")]
        public int House_Number { get; set; }

        [Required(ErrorMessage = "این قسمت باید تکمیل شود!")]
        [Display(Name = "کد پستی(بدون خط فاصله)")]
        [MinLength(15)]
        [MaxLength(15)]
        [Range(111111111111111,999999999999999,ErrorMessage="کد پستی باید عددی 15 رقمی باشد!")]
        public string Post_Code { get; set; }
    }
}
