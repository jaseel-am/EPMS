using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPMS
{
    public partial class frmWellComparisionReport : Form
    {
        frmLoading frmLodingObj = new frmLoading();
        DataTable dtblOutPut = new DataTable();

        #region Functions
        public frmWellComparisionReport()
        {
            InitializeComponent();
            if (Properties.Settings.Default.ComparisionOutputPath != string.Empty)
            {
                txtOutPutPath.Text = Properties.Settings.Default.ComparisionOutputPath;
                chkRemember.Checked = true;
            }
            FillCombo();
        }

        private void FillCombo()
        {
            try
            {
                WellSP spWell = new WellSP();
                DataTable dtbl = spWell.GetWells();
                cmbFromWell.DataSource = dtbl;
                cmbFromWell.ValueMember = "Well_Id";
                cmbFromWell.DisplayMember = "Well_Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }

        private void DoCalculation()
        {
            try
            {
                dtblOutPut = new DataTable();
                DataSet DsData = new DataSet();
                WellSP spWell = new WellSP();
                DsData = spWell.GetWellDetails(Convert.ToInt32(cmbFromWell.SelectedValue.ToString()));
                DataTable dtblFromWell = new DataTable();
                DataTable dtblToWell = new DataTable();
                if (!dtblOutPut.Columns.Contains("WellName"))
                {
                    dtblOutPut.Columns.Add("WellName");
                    dtblOutPut.Columns.Add("XVal");
                    dtblOutPut.Columns.Add("YVal");
                    dtblOutPut.Columns.Add("ZVal");
                    dtblOutPut.Columns.Add("Result");
                }
                if (DsData.Tables.Count == 2)
                {
                    dtblFromWell = DsData.Tables[0];
                    dtblToWell = DsData.Tables[1];
                }
                double decFirstXVal = 0;
                double decFirstYVal = 0;
                double decFirstZVal = 0;
                if (dtblFromWell.Rows.Count > 0)
                {
                    decFirstXVal = Convert.ToDouble(dtblFromWell.Rows[0]["X_Val"].ToString());
                    decFirstYVal = Convert.ToDouble(dtblFromWell.Rows[0]["Y_Val"].ToString());
                    decFirstZVal = Convert.ToDouble(dtblFromWell.Rows[0]["Z_Val"].ToString());
                }
                for (int i = 0; i < dtblToWell.Rows.Count; i++)
                {
                    string strWellName = dtblToWell.Rows[i]["Well_Name"].ToString();
                    double decSecXVal = Convert.ToDouble(dtblToWell.Rows[i]["X_Val"].ToString());
                    double decSecYVal = Convert.ToDouble(dtblToWell.Rows[i]["Y_Val"].ToString());
                    double decSecZVal = Convert.ToDouble(dtblToWell.Rows[i]["Z_Val"].ToString());

                    double decXVal = decFirstXVal - decSecXVal;
                    double decYVal = decFirstYVal - decSecYVal;
                    double decZVal = decFirstZVal - decSecZVal;
                    double dexXValSum = decXVal * decXVal;
                    double dexYValSum = decYVal * decYVal;
                    double dexZValSum = decZVal * decZVal;
                    double decSum = (dexXValSum + dexYValSum + dexZValSum);
                    double dbResult = Math.Sqrt(decSum);

                    DataRow dr = dtblOutPut.NewRow();
                    dr["WellName"] = dtblToWell.Rows[i]["Well_Name"].ToString();
                    dr["XVal"] = decSecXVal;
                    dr["YVal"] = decSecYVal;
                    dr["ZVal"] = decSecZVal;
                    dr["Result"] = Math.Round(dbResult, 3);
                    dtblOutPut.Rows.Add(dr);
                }
                DgvReport.DataSource = dtblOutPut;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }

        #endregion

        #region Events

        private void frmNewReport_Load(object sender, EventArgs e)
        {
            try
            {
                FillCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DoCalculation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.ComparisionOutputPath = txtOutPutPath.Text;
                }
                else
                {
                    Properties.Settings.Default.ComparisionOutputPath = string.Empty;
                }
                if (dtblOutPut.Rows.Count > 0)
                {
                    if (txtOutPutPath.Text != string.Empty)
                    {
                        bwrk1.RunWorkerAsync();
                        frmLodingObj.ShowFromOtherForms();
                    }
                    else
                    {
                        MessageBox.Show("Output Path should not be empty..!", "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }
        private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ExportToExcel objExport = new ExportToExcel();
                string strBasePath = AppDomain.CurrentDomain.BaseDirectory;
                string strFullPath = strBasePath + ConfigurationManager.AppSettings["TemplatePath"];
                string strWellCompareTempName = ConfigurationManager.AppSettings["WellCompareTempName"];
                bool isExported = objExport.StartExport(dtblOutPut, true, true, txtOutPutPath.Text, strFullPath, strWellCompareTempName, 1);
                if (isExported)
                {
                    DialogResult result = MessageBox.Show("Exported Successfully. Do you want to Open the File?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(txtOutPutPath.Text + "\\" + strWellCompareTempName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }
        private void bwrk1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (frmLodingObj != null)
                {
                    frmLodingObj.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog obj = new FolderBrowserDialog();
                DialogResult result = obj.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtOutPutPath.Text = obj.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.WriteToFile(ex.Message, false);
            }
        }

        #endregion
    }
}
