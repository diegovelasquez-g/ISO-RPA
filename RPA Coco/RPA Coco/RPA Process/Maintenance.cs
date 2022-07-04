using RPA_Coco.Models;
using RPA_Coco.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA_Coco.RPA_Process
{
    class Maintenance
    {
        RPADbContext db;
        Helper hp;

        public Maintenance()
        {
            db = new RPADbContext();
        }

        /*                                                    VARIABLE MAINTENANCE
        *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  */
        public List<Variables> GetVariables()
        {
            try
            {
                List<Variables> LstVariables = new List<Variables>();

                LstVariables = db.Variables.Where(x => x.UserVariable == true).ToList();
                return LstVariables;
            }
            catch (Exception e)
            {
                Logs log = new Logs();
                log.LogsTypeId = 1;
                log.ProcessId = 1;
                log.Message = e.Message;
                log.InnerException = e.InnerException.ToString();
                log.CreatedBy = hp.GetUserName();
                log.CreatedDate = DateTime.Now;
                hp.SaveLog(log);
                throw;
            }
        }

        public bool SaveEdit(VariablesVM model)
        {
            try
            {
                hp = new Helper();
                string UserName = hp.GetUserName();
                DateTime ModifedDate = DateTime.Now;

                List<Variables> LstVariables = new List<Variables>();
                LstVariables = db.Variables.Where(x => x.UserVariable == true).ToList();

                var VCoco_Report_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Report_Name");
                VCoco_Report_Name.Value = model.Coco_Report_Name;
                VCoco_Report_Name.ModifiedBy = UserName;
                VCoco_Report_Name.ModifiedDate = ModifedDate;

                var VCoco_Report_Path = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Folder");
                VCoco_Report_Path.Value = model.Coco_Report_Path;
                VCoco_Report_Path.ModifiedBy = UserName;
                VCoco_Report_Path.ModifiedDate = ModifedDate;

                var VCoco_Template_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Name");
                VCoco_Template_Name.Value = model.Coco_Template_Name;
                VCoco_Template_Name.ModifiedBy = UserName;
                VCoco_Template_Name.ModifiedDate = ModifedDate;


                var VCoco_Template_Path = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Folder");
                VCoco_Template_Path.Value = model.Coco_Template_Path;
                VCoco_Template_Path.ModifiedBy = UserName;
                VCoco_Template_Path.ModifiedDate = ModifedDate;

                var VEmail_Subject = LstVariables.FirstOrDefault(x => x.VariableName == "Email_Subject");
                VEmail_Subject.Value = model.Email_Subject;
                VEmail_Subject.ModifiedBy = UserName;
                VEmail_Subject.ModifiedDate = ModifedDate;

                var VEmail_To = LstVariables.FirstOrDefault(x => x.VariableName == "Email_To");
                VEmail_To.Value = model.Email_To;
                VEmail_To.ModifiedBy = UserName;
                VEmail_To.ModifiedDate = ModifedDate;

                var VEmail_CC = LstVariables.FirstOrDefault(x => x.VariableName == "Email_CC");
                VEmail_CC.Value = model.Email_CC;
                VEmail_CC.ModifiedBy = UserName;
                VEmail_CC.ModifiedDate = ModifedDate;

                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Logs log = new Logs();
                log.LogsTypeId = 1;
                log.ProcessId = 2;
                log.Message = e.Message;
                log.InnerException = e.InnerException.ToString();
                log.CreatedBy = hp.GetUserName();
                log.CreatedDate = DateTime.Now;
                hp.SaveLog(log);
                return false;
            }
        }
    }
}
