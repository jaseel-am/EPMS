using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EPMS
{
    public class WellSP : DBConnection
    {
        public void WellsInsertUpdate(WellModel objModel)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    objConn.Open();
                    SqlCommand objCmd = new SqlCommand("WellDetailsInsUpDel", objConn);
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@Well_Name", objModel.WellName);
                    objCmd.Parameters.AddWithValue("@X_Val", objModel.XValue);
                    objCmd.Parameters.AddWithValue("@Y_Val", objModel.YValue);
                    objCmd.Parameters.AddWithValue("@Z_Val", objModel.ZValue);
                    objCmd.ExecuteNonQuery();
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("WellsInsertUpdate: " + ex.ToString());
            }
        }
        public DataTable GetWells()
        {
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    if (objConn.State == ConnectionState.Closed)
                    {
                        objConn.Open();
                    }
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("GetWells", objConn);
                    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdaadapter.Fill(dtbl);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtbl;
        }
        public DataSet GetWellDetails(int inWellId)
        {
            DataSet DsData = new DataSet();
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    if (objConn.State == ConnectionState.Closed)
                    {
                        objConn.Open();
                    }
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("GetWellDetails", objConn);
                    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdaadapter.SelectCommand.Parameters.AddWithValue("@FirstWellId", inWellId);
                    sdaadapter.Fill(DsData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return DsData;
        }
    }
}
