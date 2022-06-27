using RPA_Coco.RPA_Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPA_Coco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Helper hp = new Helper();
            string conexion = "Data Source=SVSALSQL001;Initial Catalog=RPA;User Id=5vc_osSQL_RPACocoOwner;Password=k5Y7hW3jyHVNP8JcWx";
            string encrip = "aba4jnkfcuX6CTloNerP2Qiiwhe2x+BO+tRMZv6DKLfV34cYtdvEYfIIPSZFQbm+dgbGP/Y02cNjEXz7l/B0IpB/9mUortsyyCge3vEPeDMUzO4jM0aUBo28nDCL1bGCjL7SZl40xn9TFZDuMHK8vg==";
            var cadena = hp.Desencriptar(encrip);
        }
    }
}
