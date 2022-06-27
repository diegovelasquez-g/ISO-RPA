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
    public partial class Loading : Form
    {
        public Action Worker { get; set; }
        public Loading(Action worker)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Start new thread to run wait form dialog
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #region Bordes
        private void Loading_Paint(object sender, PaintEventArgs e)
        {
            Pen c = (new Pen(Brushes.Green, 1));
            Graphics Linea = CreateGraphics();
            Linea.DrawLine(c, new Point(Width - 1, 0), new Point(Width - 1, Height - 1));//lado derecho
            Linea.DrawLine(c, new Point(0, 0), new Point(0, Height - 1));//lado izquierdo
            Linea.DrawLine(c, new Point(0, Height - 1), new Point(Width, Height - 1));//lado de abajo
            Linea.DrawLine(c, new Point(Width, 0), new Point(0, 0));
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
