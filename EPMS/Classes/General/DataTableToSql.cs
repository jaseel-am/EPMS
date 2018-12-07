using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS
{
    public class DataTableToSql
    {
        string sqlconn;
        SqlConnection con;
        public bool StartCopy(DataTable dtblData, string strTableName)
        {
            bool isSuccess = false;
            try
            {
                SPMasterSettings objSp = new SPMasterSettings();
                objSp.ExicuteRuntimeQuery("TRUNCATE TABLE " + strTableName);
                if (dtblData.Rows.Count > 0)
                {
                    sqlconn = ConfigurationManager.AppSettings["SqlConnection"].ToString();
                    con = new SqlConnection(sqlconn);
                    //creating object of SqlBulkCopy    
                    SqlBulkCopy objbulkRaw = new SqlBulkCopy(con);
                    //assigning Destination table name    
                    objbulkRaw.DestinationTableName = "dbo." + strTableName;
                    //Mapping Table column    
                    for (int i = 0; i < dtblData.Columns.Count; i++)
                    {
                        objbulkRaw.ColumnMappings.Add(dtblData.Columns[i].ColumnName, dtblData.Columns[i].ColumnName);
                    }
                    //inserting Datatable Records to DataBase    
                    con.Open();
                    objbulkRaw.BulkCopyTimeout = 6000;
                    objbulkRaw.BatchSize = 5000;
                    objbulkRaw.BulkCopyTimeout = 60;
                    objbulkRaw.WriteToServer(dtblData);
                    con.Close();
                    isSuccess = true;
                }
                if (dtblData.Rows.Count == 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return isSuccess;
        }

        public string CreateTable(DataTable dtbl, string strWellName)
        {
            string strTabName = "";
            string strFinal = string.Empty;
            try
            {
                if (dtbl.Columns.Count > 0)
                {
                    strTabName = "Las_" + strWellName;
                    string strDropQuery = "IF OBJECT_ID('dbo.Las_" + strWellName + "', 'U') IS NOT NULL  DROP TABLE dbo.Las_" + strWellName + "; ";
                    string strQuery = strDropQuery + " CREATE TABLE Las_" + strWellName + "(";
                    for (int i = 0; i < dtbl.Columns.Count; i++)
                    {
                        strQuery += "[" + dtbl.Columns[i].ColumnName.ToString() + "] NVARCHAR(MAX),";
                    }
                    strFinal = strQuery.TrimEnd(',') + ");";
                    SPMasterSettings objSp = new SPMasterSettings();
                    objSp.ExicuteRuntimeQuery(strFinal);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strTabName;
        }
    }
}
