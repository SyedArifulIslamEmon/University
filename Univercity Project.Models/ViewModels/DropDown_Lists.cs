using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Univercity_Project.Models.ViewModels
{
    public class DropDown_Lists
    {
        public static List<SelectListItem> Status_list = new List<SelectListItem>
        {
            new SelectListItem() {Text="شاغل",Value="1"}
        };

        public static List<SelectListItem> Type_List = new List<SelectListItem>
        {
            new SelectListItem() {Text="رسمی" , Value="1"},
            new SelectListItem() {Text="پیمانی" , Value ="2"}
        };

        public static List<SelectListItem> Marriage_List = new List<SelectListItem>
        {
            new SelectListItem() {Text="مجرد" , Value="1"},
            new SelectListItem() {Text="متأهل" , Value ="2"}
        };

        public static List<SelectListItem> Gender_List = new List<SelectListItem>
        {
            new SelectListItem() {Text="مرد",Value="1"},
            new SelectListItem() {Text="زن", Value="2"}
        };
    }
}
