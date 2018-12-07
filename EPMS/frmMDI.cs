using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPMS
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void wellComparisonDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmWellComparisionData frm = new frmWellComparisionData();
                frmWellComparisionData open = Application.OpenForms["frmWellComparisionData"] as frmWellComparisionData;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    open.Activate();
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 1: " + ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void wellComparisionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmWellComparisionReport frm = new frmWellComparisionReport();
                frmWellComparisionReport open = Application.OpenForms["frmWellComparisionReport"] as frmWellComparisionReport;
                if (open == null)
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    open.Activate();
                    if (open.WindowState == FormWindowState.Minimized)
                    {
                        open.WindowState = FormWindowState.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MDI 2: " + ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
