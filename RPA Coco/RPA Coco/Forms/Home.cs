using RPA_Coco.RPA_Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPA_Coco.Forms
{
    public partial class Home : Form
    {
        DialogWindow ExecutionDialog = new DialogWindow();
        public static Home SendHome;
        public int Progress = 0;
        AutomaticProcess Process = new AutomaticProcess();
        public bool ProcessRestarted = false;
        public Home()
        {
            InitializeComponent();
            SendHome = this;
            lbCopyright.Text = "Copyright © " + DateTime.Now.Year.ToString();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /*                                                  BOTONES
         *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  */
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            MailBoxMaintenance maintenance = new MailBoxMaintenance();
            Loading load = new Loading(Timing);
            load.ShowDialog(this);
            maintenance.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.DeleteCopy();
            Application.Exit();

        }


        /*                                                   PROCESO
         *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  */


        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        public void btnStartProcess_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false;
            pgb.Visible = true;
            pgb.Minimum = 0;
            pgb.Maximum = 1000;
            pgb.Step = 1;
            pgb.Value = 0;
            PrintProcessMessage("Iniciando proceso", 1);
            PrintProcessMessage("Obteniendo variables desde la base de datos", 1);
            bgwVariables.RunWorkerAsync();
        }

        #region PROCEDIMIENTOS AUXILIARES
        public void PrintProcessMessage(string message, int type) //1: normal text || 2: error text
        {
            if (type == 1)
                rtxtSteps.SelectionColor = Color.White;
            else
                rtxtSteps.SelectionColor = Color.DarkRed;

            rtxtSteps.AppendText($"{message}{Environment.NewLine} ");
            rtxtSteps.SelectionStart = this.rtxtSteps.Text.Length;
            rtxtSteps.SelectionLength = 0;
            rtxtSteps.ScrollToCaret();
        }

        //Used in Loading form
        void Timing()
        {
            for (int i = 0; i <= 500; i++)
            {
                Thread.Sleep(10);
            }
        }
        #endregion

        #region Mover Barra Titulo
        bool Empezarmover = false;
        int PosX;
        int PosY;

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = true;
                PosX = e.X;
                PosY = e.Y;
            }
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Empezarmover)
            {
                Point temp = new Point();
                temp.X = Location.X + (e.X - PosX);
                temp.Y = Location.Y + (e.Y - PosY);
                Location = temp;
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Empezarmover = false;
            }
        }
        #endregion

        #region Bordes
        private void Home_Paint(object sender, PaintEventArgs e)
        {
            Pen c = (new Pen(Brushes.LightGray, 1));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 1), new Point(Width - 1, Height - 1));
            Linea.DrawLine(c, new Point(0, 0), new Point(0, Height - 1));
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));
            Linea.DrawLine(c, new Point(Width, 1), new Point(0, 1));
        }
        #endregion

        #region Sombra
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        #endregion

        public void Proceso()
        {
            panelWelcome.Visible = false;
            pgb.Visible = true;
            pgb.Minimum = 0;
            pgb.Maximum = 1000;
            pgb.Step = 1;
            pgb.Value = 0;
            PrintProcessMessage("Iniciando proceso", 1);
            PrintProcessMessage("Obteniendo variables desde la base de datos", 1);
            bgwVariables.RunWorkerAsync();
        }

        #region RPAProcess
        //Get Variables

        private void bgwVariables_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.GetVariables();
            Progress += 30;
            bgwVariables.ReportProgress(Progress);
        }

        private void bgwVariables_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwVariables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("Variables obtenidas correctamente", 1);
                PrintProcessMessage("Comprobando directorios de los archivos", 1);
                bgwDirectories.ReportProgress(Progress);
                bgwDirectories.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Error getting the variables from the database", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        //Directories
        private void bgwDirectories_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Process.CheckDirectories();
            Progress += 30;
            bgwDirectories.ReportProgress(Progress);
        }

        private void bgwDirectories_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwDirectories_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.ToString() != "")
                {
                    PrintProcessMessage($"ERROR: {e.Result}", 2);
                }
                else
                {
                    PrintProcessMessage($"Directorios comprobados", 1);
                    Progress += 70;
                    bgwCopyFile.ReportProgress(Progress);
                    PrintProcessMessage("Copiando Template a la carpeta de Workflow", 1);
                    Progress += 70;
                    bgwCopyFile.ReportProgress(Progress);
                    bgwCopyFile.RunWorkerAsync();
                }
            }
            else
            {
                PrintProcessMessage("Error with the directories", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwCopyFile_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Process.CopyTemplate();
            Progress += 30;
            bgwCopyFile.ReportProgress(Progress);
        }

        private void bgwCopyFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwCopyFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.ToString() != "")
                {
                    PrintProcessMessage($"ERROR: {e.Result}", 2);
                }
                else
                {
                    PrintProcessMessage($"Copiado y pegado del template completado", 1);
                    PrintProcessMessage("Abriendo Template y Reporte ", 1);
                    Progress += 70;
                    bgwCocoReport.ReportProgress(Progress);
                    bgwCocoReport.RunWorkerAsync();

                }
            }
            else
            {
                PrintProcessMessage("Error meanwhile copying file to Workflow Folder", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwCocoReport_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.OpenBothExcel();
            Progress += 70;
            bgwCocoReport.ReportProgress(Progress);
        }

        private void bgwCocoReport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwCocoReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("Los archivos han sido abiertos sin problemas", 1);
                PrintProcessMessage("Aplicando los filtros correspondientes al reporte", 1);
                Progress += 70;
                bgwTemplate.ReportProgress(Progress);
                bgwTemplate.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Error while the filters was applying to the file.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwTemplate_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.CocoReportFilters();
            Progress += 70;
            bgwTemplate.ReportProgress(Progress);
        }

        private void bgwTemplate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwTemplate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("Filtros aplicados correctamente", 1);
                PrintProcessMessage("Copiando data filtrada.", 1);
                bgwCopyCocoReport.ReportProgress(Progress);
                bgwCopyCocoReport.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Error while the filters was applied.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }


        private void bgwCopyCocoReport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwCopyCocoReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("La copia ha sido realizado", 1);
                PrintProcessMessage("Pegando la data en el archivo del template.", 1);
                bgwPasteDataTemplate.ReportProgress(Progress);
                bgwPasteDataTemplate.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Error copying the data.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwPasteDataTemplate_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.PasteDataTemplate();
            Progress += 70;
            bgwPasteDataTemplate.ReportProgress(Progress);
        }

        private void bgwPasteDataTemplate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwPasteDataTemplate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("El pegado ha sido completado", 1);
                PrintProcessMessage("Trabajando en el Template", 1);
                PrintProcessMessage("Transformando la data y generando la Pivot Table", 1);
                bgwWorkTemplate.ReportProgress(Progress);
                bgwWorkTemplate.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Failed to paste data into file.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwWorkTemplate_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.WorkingOnTemplate();
            Progress += 70;
            bgwWorkTemplate.ReportProgress(Progress);
        }

        private void bgwWorkTemplate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwWorkTemplate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("Se completó el trabajo en el template", 1);
                PrintProcessMessage("Generando EMAIL", 1);
                bgwEmail.ReportProgress(Progress);
                bgwEmail.RunWorkerAsync();
            }
            else
            {
                PrintProcessMessage("Error while creating and sending the email.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwEmail_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb.Value = e.ProgressPercentage;
        }

        private void bgwEmail_DoWork(object sender, DoWorkEventArgs e)
        {
            Process.SendEmail();
            Progress = 1000;
            bgwEmail.ReportProgress(Progress);
        }

        private void bgwEmail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                PrintProcessMessage("Email sending was successfully.", 1);
                PrintProcessMessage("The process has been completed successfully.", 1);
                Process.CloseExcels();
            }
            else
            {
                PrintProcessMessage("Error while the email was sending.", 2);
                PrintProcessMessage($"ERROR: {e.Error.Message}", 2);
            }
        }

        private void bgwCopyCocoReport_DoWork(object sender, DoWorkEventArgs e)
        {
            ;
            Process.CopyDataCocoReport();
            Progress += 70;
            bgwCopyCocoReport.ReportProgress(Progress);
        }

        #endregion

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Process.CloseExcels();
            Process.DeleteCopy();
            Home home = new Home();
            home.ProcessRestarted = true;
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            DialogResult IsAutomaticExecution = ExecutionDialog.ShowDialog();
            if (IsAutomaticExecution == DialogResult.Yes)
            {
                Proceso();
            }
            else
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
