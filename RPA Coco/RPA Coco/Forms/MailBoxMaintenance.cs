using RPA_Coco.Models;
using RPA_Coco.Models.ViewModels;
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
    public partial class MailBoxMaintenance : Form
    {
        Maintenance maintenance = new Maintenance();

        public MailBoxMaintenance()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void MailBoxMaintenance_Load(object sender, EventArgs e)
        {
            List<Variables> LstVariables = maintenance.GetVariables();

            var VCoco_Report_Path = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Folder");
            txtReportPath.Text = VCoco_Report_Path.Value;

            var VCoco_Report_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Report_Name");
            txtReportName.Text = VCoco_Report_Name.Value;

            var VCoco_Template_Path = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Folder");
            txtTemplate.Text = VCoco_Template_Path.Value;

            var VCoco_Template_Name = LstVariables.FirstOrDefault(x => x.VariableName == "Template_Name");
            txtTemplateName.Text = VCoco_Template_Name.Value;

            var VEmail_Subject = LstVariables.FirstOrDefault(x => x.VariableName == "Email_Subject");
            txtSubject.Text = VEmail_Subject.Value;

            var VEmail_To = LstVariables.FirstOrDefault(x => x.VariableName == "Email_To");
            txtTo.Text = VEmail_To.Value;

            var VEmail_CC = LstVariables.FirstOrDefault(x => x.VariableName == "Email_CC");
            txtCC.Text = VEmail_CC.Value;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool Continue = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        MessageBox.Show("You cannot leave empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Continue = false;
                        break;
                    }
                }
            }
            if (Continue)
            {
                var ConfirmEdit = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Save Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ConfirmEdit == DialogResult.Yes)
                {
                    try
                    {
                        Loading frm = new Loading(Timing);
                        frm.ShowDialog(this);
                        VariablesVM model = new VariablesVM();
                        model.Coco_Report_Path = txtReportPath.Text;
                        model.Coco_Report_Name = txtReportName.Text;
                        model.Coco_Template_Path = txtTemplate.Text;
                        model.Coco_Template_Name = txtTemplateName.Text;
                        model.Email_Subject = txtSubject.Text;
                        model.Email_To = txtTo.Text;
                        model.Email_CC = txtCC.Text;

                        bool Saved = maintenance.SaveEdit(model);
                        if (Saved)
                        {
                            MessageBox.Show("Changes saved successfully", "Saved", MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        void Timing()
        {
            for (int i = 0; i <= 500; i++)
            {
                Thread.Sleep(10);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        private void MailboxMaintenance_Paint(object sender, PaintEventArgs e)
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
    }
}
