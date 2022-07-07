using RPA_Coco.Models;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;
using Process = System.Diagnostics.Process;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.Text;

namespace RPA_Coco.RPA_Process
{
    class AutomaticProcess
    {
        //Used to kill interop Excel process
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        uint processId1 = 0;

        #region VariablesGlobales
        MSExcel.Workbook WBFileReport;
        MSExcel.Worksheet WSPivot;
        MSExcel.Worksheet WSFileReport;
        MSExcel.Worksheet WSFileWorkflow;
        MSExcel.Workbook WBFileTemplate;
        MSExcel.Worksheet WSRawData;
        MSExcel.Worksheet WSRoster;
        MSExcel.Worksheet WSEmail;
        MSExcel.Range to;
        string rang;
        #endregion

        //Initialize
        readonly Helper hp;
        readonly RPADbContext db;
        List<Variables> LstVariables;


        //Datetime variable
        DateTime Now;

        //Folder Paths
        string Coco_Template_Folder = string.Empty;
        string Coco_Workflow_Folder = string.Empty;

        //File Names
        string Coco_Template_Name = string.Empty;
        string Coco_Report_Name = string.Empty;

        //File Paths
        string Coco_Report_Path = string.Empty;
        string Coco_Template_Path = string.Empty;

        //Template Copy Path
        string Coco_Template_Copy_Path = string.Empty;


        public AutomaticProcess()
        {
            hp = new Helper();
            db = new RPADbContext();

            Now = DateTime.Now;
        }

        public void GetVariables()
        {
            try
            {
                LstVariables = db.Variables.Where(x => x.Enabled == true).ToList();
            }
            catch (Exception e)
            {
                Logs log = new Logs();
                log.ProcessId = 1;
                log.LogsTypeId = 1;
                log.Message = e.Message;
                log.CreatedBy = "RPA";
                log.CreatedDate = DateTime.Now;
                log.Enabled = true;
                hp.SaveLog(log);
            }
        }

        public string CheckDirectories()
        {
            try
            {
                //Folders
                Coco_Template_Folder = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Folder").Value;
                Coco_Workflow_Folder = LstVariables.FirstOrDefault(x => x.VariableName == "Workflow_Folder").Value;

                //File Names
                Coco_Template_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Name").Value;
                Coco_Report_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Report_Name").Value;

                //File Paths
                Coco_Report_Path = Path.Combine(Coco_Template_Folder, Coco_Report_Name);
                Coco_Template_Path = Path.Combine(Coco_Template_Folder, Coco_Template_Name);

                Coco_Template_Copy_Path = Path.Combine(Coco_Workflow_Folder, Coco_Template_Name);

                if (!hp.DirectoryExists(Coco_Template_Folder))
                {
                    return $"{Coco_Template_Folder} does not exists";
                }
                else
                {
                    if (!hp.FileExists(Coco_Report_Path))
                    {
                        return $"{Coco_Report_Name} file does not exists in the path {Coco_Report_Path}";
                    }
                }

                if (!hp.DirectoryExists(Coco_Workflow_Folder))
                {
                    return $"{Coco_Workflow_Folder} does not exists";
                }

                return ""; //Return nothing if everything was ok
            }
            catch (Exception e)
            {
                //Logs log = new Logs();
                //log.ProcessId = 4;
                //log.LogsTypeId = 1;
                //log.Message = e.Message;
                //log.CreatedBy = "RPA";
                //log.CreatedDate = DateTime.Now;
                //log.Enabled = true;
                //hp.SaveLog(log);
                return e.Message;
            }
        }

        public string CopyTemplate()
        {
            try
            {
                DeleteCopy();
                string fileCopy = Coco_Template_Path;
                string name = Path.GetFileName(fileCopy);
                string destination = Coco_Workflow_Folder + "\\" + name;
                File.Copy(fileCopy, destination);

                return "";
            }
            catch (Exception e)
            {
                //Logs log = new Logs();
                //log.ProcessId = 5;
                //log.LogsTypeId = 1;
                //log.Message = e.Message;
                //log.CreatedBy = "RPA";
                //log.CreatedDate = DateTime.Now;
                //log.Enabled = true;
                //hp.SaveLog(log);
                return e.Message;
            }
        }

        public void DeleteCopy()
        {
            string fileCopy = Coco_Template_Path;
            Variables v = new Variables();
            //string name = Path.GetFileName(fileCopy);
            //string destination = Coco_Workflow_Folder + "\\" + name;
            string path = "\\\\svsalfil002\\its\\IS\\Application Publish\\RPA Coco\\Workflow\\Coco Open Attestations.xlsx";
            v = db.Variables.Where(x => x.VariableName == "DeleteTemp").FirstOrDefault();
            string path2 = v.Value.ToString();
            
            if (hp.FileExists(path2))
            {
                File.Delete(path2);
            }
        }

        public string OpenBothExcel()
        {
            try
            {
                MSExcel.Application ApplicationExcel = new MSExcel.Application();
                ApplicationExcel.Visible = true;
                ApplicationExcel.DisplayAlerts = false;
                GetWindowThreadProcessId(new IntPtr(ApplicationExcel.Hwnd), out processId1);
                //Coco Report
                WBFileReport = ApplicationExcel.Workbooks.Open(Coco_Report_Path, ReadOnly: false);
                WSFileReport = WBFileReport.Sheets[1];
                //Copy Template
                WBFileTemplate = ApplicationExcel.Workbooks.Open(Coco_Template_Copy_Path, ReadOnly: false);
                WSFileWorkflow = WBFileTemplate.Sheets[1];
                WSFileReport.Activate();
                return "";
            }
            catch(Exception e)
            {
                CloseExcels();
                //Logs log = new Logs();
                //log.ProcessId = 6;
                //log.LogsTypeId = 1;
                //log.Message = e.Message;
                //log.CreatedBy = "RPA";
                //log.CreatedDate = DateTime.Now;
                //log.Enabled = true;
                //hp.SaveLog(log);
                return e.Message;
            }
        }

        public string CocoReportFilters()
        {
            try
            {
                WSFileReport.AutoFilterMode = false;
                WSFileReport.EnableAutoFilter = true;
                int UltimaFila = WSFileReport.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;
                MSExcel.Range range = WSFileReport.get_Range("A1", "R1");
                range.AutoFilter("1", "<>", MSExcel.XlAutoFilterOperator.xlOr, "", true);
                var y = range.AutoFilter(13, "<>BECNBG", MSExcel.XlAutoFilterOperator.xlAnd, "<>BHAVOC");
                DateTime day = DateTime.Now;
                int dt1 = 2021;
                int dt2 = 2022;
                //string colummn = LstVariables.FirstOrDefault(x => x.VariableName == "NewCellCocoReport").Value;
                string column1 = "B1";
                string column2 = "B2";
                //string createdDate = LstVariables.FirstOrDefault(x => x.VariableName == "CreatedDateCell").Value;


                //Creando nueva columna
                MSExcel.Range rng = WSFileReport.get_Range(column1, Type.Missing);
                rng.EntireColumn.Insert(MSExcel.XlInsertShiftDirection.xlShiftToRight,
                        MSExcel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);

                MSExcel.Range rng2 = WSFileReport.get_Range(column2, Type.Missing);
                rng2.EntireColumn.Value2 = "=LEFT(A1,4)";
                rng2.EntireColumn.NumberFormat = "0";
                WSFileReport.get_Range(column1).Value2 = "Year";



                return "";
            }
            catch(Exception e)
            {
                Logs log = new Logs();
                log.ProcessId = 7;
                log.LogsTypeId = 1;
                log.Message = e.Message;
                log.CreatedBy = "RPA";
                log.CreatedDate = DateTime.Now;
                log.Enabled = true;
                hp.SaveLog(log);
                CloseExcels();
                return e.Message;
            }
        }

        public string CopyDataCocoReport()
        {
            try
            {
                int UltimaFila = WSFileReport.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;
                int PrimeraFila = WSFileReport.UsedRange.Row;

                //string x1 = LstVariables.FirstOrDefault(x => x.VariableName == "FirstCopyCocoReport").Value;
                //string x2 = LstVariables.FirstOrDefault(x => x.VariableName == "LastCopyCocoReport").Value;


                string rango = "A" + PrimeraFila.ToString() + ":Q" + UltimaFila.ToString();
                WSFileReport.UsedRange.Cells.Range[rango].Copy(Type.Missing);
                return "";
            }
            catch(Exception e)
            {
                Logs log = new Logs();
                log.ProcessId = 8;
                log.LogsTypeId = 1;
                log.Message = e.Message;
                log.CreatedBy = "RPA";
                log.CreatedDate = DateTime.Now;
                log.Enabled = true;
                hp.SaveLog(log);
                CloseExcels();
                return e.Message;
            }
        }

        public string PasteDataTemplate()
        {
            try
            {
                WBFileTemplate.Activate();
                to = WSFileWorkflow.Cells.get_Range("A1", Type.Missing);
                WSFileWorkflow.Paste(to);

                //Refresh
                WBFileTemplate.RefreshAll();
                return "";
            }
            catch (Exception e)
            {
                Logs log = new Logs();
                log.ProcessId = 9;
                log.LogsTypeId = 1;
                log.Message = e.Message;
                log.CreatedBy = "RPA";
                log.CreatedDate = DateTime.Now;
                log.Enabled = true;
                hp.SaveLog(log);
                CloseExcels();
                return e.Message;
            }
        }
        
        public string WorkingOnTemplate()
        {
            try
            {
                WSRawData = WBFileTemplate.Sheets[2];
                WSPivot = WBFileTemplate.Sheets[3];
                WSEmail = WBFileTemplate.Sheets[4];
                //WSRoster = WBFileTemplate.Sheets[4];
                WSFileWorkflow.Columns["A"].Delete();

                int UltimaFila = WSFileWorkflow.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;
                int PrimeraFila = WSFileWorkflow.UsedRange.Row;

                string rango = "A" + PrimeraFila.ToString() + ":O" + UltimaFila.ToString();
                WSFileWorkflow.UsedRange.Cells.Range[rango].Copy(Type.Missing);
                WSRawData.Activate();
                MSExcel.Range r = WSRawData.Cells.get_Range("A1", Type.Missing);
                WSRawData.Paste(r);


                //Generando tabla

                UltimaFila = WSRawData.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;
                PrimeraFila = WSRawData.UsedRange.Row;

                rango = "A1" + ":O298657";
                MSExcel.Range ra = WSRawData.get_Range(rango);


                WSRawData.AutoFilterMode = false;
                WSRawData.ListObjects.AddEx(MSExcel.XlListObjectSourceType.xlSrcRange, ra, Type.Missing, MSExcel.XlYesNoGuess.xlYes, Type.Missing).Name = "Table1";

                WSRawData.ListObjects.get_Item("Table1").TableStyle = "TableStyleMedium2";

                WBFileTemplate.RefreshAll();

                WSPivot.Activate();

                //WSEmail.Activate();


                UltimaFila = WSPivot.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;

                //WSPivot.get_Range("B4", "J" + UltimaFila).Cells.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                UltimaFila = WSPivot.Cells.SpecialCells(MSExcel.XlCellType.xlCellTypeLastCell).Row;
                rang = "A1" + ":J" + UltimaFila.ToString();


                return "";
            }
            catch (Exception e)
            {
                //Logs log = new Logs();
                //log.ProcessId = 10;
                //log.LogsTypeId = 1;
                //log.Message = e.Message;
                //log.CreatedBy = "RPA";
                //log.CreatedDate = DateTime.Now;
                //log.Enabled = true;
                //hp.SaveLog(log);
                CloseExcels();
                return e.Message;
            }
        }

        [STAThread]
        public string SendEmail()
        {
            try
            {
                Thread STAThread = new Thread(
            delegate ()
            {
                //Clipboard.Clear();
                WSFileWorkflow.Delete();
                WSPivot.UsedRange.Cells.Range[rang].Copy(Type.Missing);
                string myNewText = Clipboard.GetText(TextDataFormat.Rtf);
                WSEmail.Delete();
                WBFileTemplate.Save();
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.NameSpace nameSpace = outlookApp.GetNamespace("MAPI");
                nameSpace.Logon("RPA");
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
                oMailItem.GetInspector.Activate();
                oMailItem.BodyFormat = Outlook.OlBodyFormat.olFormatRichText;
                byte[] myNewRtfBytes = Encoding.UTF8.GetBytes(myNewText);
                oMailItem.Display();
                oMailItem.To = LstVariables.FirstOrDefault(x => x.VariableName == "Email_To").Value;
                oMailItem.Subject = LstVariables.FirstOrDefault(x => x.VariableName == "Email_Subject").Value;
                oMailItem.CC = LstVariables.FirstOrDefault(x => x.VariableName == "Email_CC").Value;
                oMailItem.RTFBody = myNewRtfBytes;
                CloseExcels();
                string fileCopy = Coco_Template_Path;
                string name = Path.GetFileName(fileCopy);
                string destination = Coco_Workflow_Folder + "\\" + name;
                oMailItem.Attachments.Add(Coco_Template_Copy_Path);
                oMailItem.Send();
            });
                STAThread.SetApartmentState(ApartmentState.STA);
                STAThread.Start();
                STAThread.Join();
                return "";
            }
            catch (Exception e)
            {
                //Logs log = new Logs();
                //log.ProcessId = 11;
                //log.LogsTypeId = 1;
                //log.Message = e.Message;
                //log.CreatedBy = "RPA";
                //log.CreatedDate = DateTime.Now;
                //log.Enabled = true;
                //hp.SaveLog(log);
                CloseExcels();
                return e.Message;
            }
        }

        public void CloseExcels()
        {
            //Matando el proceso
            if (processId1 != 0)
            {
                Process excelProcess1 = Process.GetProcessById((int)processId1);
                excelProcess1.CloseMainWindow();
                excelProcess1.Refresh();
                excelProcess1.Kill();
                excelProcess1.Refresh();
                processId1 = 0;
            }
        }

      
    }
}
