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

namespace EPMS
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Environment.ExitCode = 1;
            this.Close();
        }
    }
}
