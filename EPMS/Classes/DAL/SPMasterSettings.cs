using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS
{
    public class SPMasterSettings : DBConnection
    {
        public DataTable GetMasterSettingsAll(string strType)
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
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("GetSystemSetings", objConn);
                    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdaadapter.SelectCommand.Parameters.AddWithValue("@type", strType);
                    sdaadapter.Fill(dtbl);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtbl;
        }
        public void ExicuteRuntimeQuery(string strQuery)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    objConn.Open();
                    SqlCommand objCmd = new SqlCommand(strQuery, objConn);
                    objCmd.CommandType = CommandType.Text;
                    objCmd.ExecuteNonQuery();
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                Common.WriteToFile("CreateTableInTempDatabase: " + ex.ToString(), false);
            }
        }
        public DataTable GetLASTableNames()
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
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("GetLASTableNames", objConn);
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

        public DataTable GetReport(string strTable)
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
                    SqlDataAdapter sdaadapter = new SqlDataAdapter("GetReport", objConn);
                    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sdaadapter.SelectCommand.Parameters.AddWithValue("@table", strTable);
                    sdaadapter.Fill(dtbl);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtbl;
        }
    }
}
