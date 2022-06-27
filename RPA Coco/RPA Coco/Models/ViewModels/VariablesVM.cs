using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA_Coco.Models.ViewModels
{
    class VariablesVM
    {
        public string Coco_Report_Path { get; set; }
        public string Coco_Report_Name { get; set; }

        public string Coco_Template_Path { get; set; }
        public string Coco_Template_Name { get; set; }
        public string Email_Subject { get; set; }
        public string Email_To { get; set; }
        public string Email_CC { get; set; }
    }
}
