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
    public partial class frmWellComparisionData : Form
    {
        #region Functions
        public frmWellComparisionData()
        {
            InitializeComponent();
            if (Properties.Settings.Default.ComparionDataFilePath != string.Empty)
            {
                txtFilePath.Text = Properties.Settings.Default.ComparionDataFilePath;
                txtSheet.Text = Properties.Settings.Default.ComparisionDataFileName;
                chkRemember.Checked = true;
            }
        }
       
        private void CreateComboBox(ComboBox cmbIn, DataTable dtbl)
        {
            try
            {
                DataTable dtblN = new DataTable();
                dtblN.Columns.Add("Id", typeof(int));
                dtblN.Columns.Add("Name", typeof(string));
                for (int i = 0; i < dtbl.Columns.Count; i++)
                {
                    dtblN.Rows.Add(i, dtbl.Columns[i].ColumnName);
                }
                cmbIn.DataSource = dtblN;
                cmbIn.ValueMember = "Id";
                cmbIn.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmImportToDb: " + ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ReadAndSaveMaster()
        {
            try
            {
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.ComparionDataFilePath = txtFilePath.Text;
                    Properties.Settings.Default.ComparisionDataFileName = txtSheet.Text;
                }
                else
                {
                    Properties.Settings.Default.ComparionDataFilePath = string.Empty;
                    Properties.Settings.Default.ComparisionDataFileName = string.Empty;
                }

                ReadFromExcel objread = new ReadFromExcel();
                DataTable dtData = objread.ReadExcelFile(txtFilePath.Text.Trim(), txtSheet.Text.Trim(), "YES");
                DataTableToSql objSql = new DataTableToSql();
                DgvMasterSettings.DataSource = dtData;

                CreateComboBox(cmbXValue, dtData);
                CreateComboBox(cmbYValue, dtData);
                CreateComboBox(cmbZValue, dtData);

                DataTable dtblWells;
                dtblWells = dtData.Copy();
                int incount = dtblWells.Columns.Count;
                for (int i = 0; i <= incount; i++)
                {
                    if (i > 0 && dtblWells.Columns.Count > 1)
                    {
                        dtblWells.Columns.RemoveAt(1);
                    }
                }
                dtblWells.Columns[0].ColumnName = "Well_Name";
                bool isResult = objSql.StartCopy(dtblWells, "Tbl_Wells");
                if (isResult)
                {
                    MessageBox.Show("Data Imported successfully.! Well Master Saved", "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Wells Not Copied.!", "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmImportToDb: " + ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Events
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog obj = new OpenFileDialog();
                DialogResult result = obj.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtFilePath.Text = obj.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmImportToDb: " + ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFilePath.Text != string.Empty && txtSheet.Text != string.Empty)
                {
                    ReadAndSaveMaster();
                }
                else
                {
                    MessageBox.Show("Output Path should not be empty..!", "EPMS-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbXValue.SelectedIndex > -1 && cmbYValue.SelectedIndex > -1 && cmbZValue.SelectedIndex > -1)
                {
                    if (DgvMasterSettings.Rows.Count > 0)
                    {
                        // Truncate Old Data
                        SPMasterSettings objSpTrun = new SPMasterSettings();
                        objSpTrun.ExicuteRuntimeQuery("TRUNCATE TABLE Tbl_Wells_Details");

                        // Insert New Data
                        string strXVal = cmbXValue.Text;
                        string strYVal = cmbYValue.Text;
                        string strZVal = cmbZValue.Text;
                        for (int i = 0; i < DgvMasterSettings.Rows.Count; i++)
                        {
                            WellModel objModel = new WellModel();
                            WellSP objSp = new WellSP();
                            try
                            {
                                if (DgvMasterSettings.Rows[i].Cells[0].Value != null)
                                {
                                    objModel.WellName = DgvMasterSettings.Rows[i].Cells[0].Value.ToString();

                                    objModel.XValue = Convert.ToDecimal(DgvMasterSettings.Rows[i].Cells[strXVal].Value.ToString() != string.Empty ? DgvMasterSettings.Rows[i].Cells[strXVal].Value : 0);
                                    objModel.YValue = Convert.ToDecimal(DgvMasterSettings.Rows[i].Cells[strYVal].Value.ToString() != string.Empty ? DgvMasterSettings.Rows[i].Cells[strYVal].Value : 0);
                                    objModel.ZValue = Convert.ToDecimal(DgvMasterSettings.Rows[i].Cells[strZVal].Value.ToString() != string.Empty ? DgvMasterSettings.Rows[i].Cells[strZVal].Value : 0);
                                    objSp.WellsInsertUpdate(objModel);
                                }

                            }
                            catch (Exception exe)
                            {
                                MessageBox.Show("Well Details Insert Error at: " + objModel.WellName, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        MessageBox.Show("All Data Saved to database Successfully..!", "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Load the data first", "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("X Y Z Values mandatory. Please select it first", "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EPMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
