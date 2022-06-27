using RPA_Coco.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPA_Coco.Forms
{
    public partial class DialogWindow : Form
    {
        int cont;
        public DialogWindow()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            using (RPADbContext db = new RPADbContext())
            {
                
                try
                {
                    var resultado = db.Variables.FirstOrDefault(x => x.VariableName == "Counter");
                    cont = int.Parse(resultado.Value);
                }
                catch (Exception e)
                {
                    throw;
                }
                
            }
        }

        private void countdown_Tick(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            countdown.Stop();
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void DialogWindow_Load(object sender, EventArgs e)
        {
            countdown = new System.Windows.Forms.Timer();
            countdown.Tick += new EventHandler(Countdown);
            countdown.Interval = 1000;
            countdown.Start();
        }

        private void Countdown(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                countdown.Stop();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else if (cont > 0)
            {
                cont--;
                btnCancel.Text = "Cancel (" + cont.ToString() + "s)";
            }
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
    }
}
