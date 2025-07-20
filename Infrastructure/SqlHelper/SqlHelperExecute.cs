using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlHelper
{
    public class SqlHelperExecute
    {
        public DataTable DataTableReader(SqlCommand command, out int Out, out string message)
        {
            using (DataTable dtResult = new DataTable())
            {
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtResult.Load(reader);
                    }
                    int result = -1;
                    string messageResult = "";

                    var paramlist = command.Parameters;

                    if (paramlist.Contains("@Out"))
                    {
                        result = (int)command.Parameters["@out"].Value;
                    }
                    if (paramlist.Contains("@message"))
                    {
                        messageResult = (string)command.Parameters["@message"].Value;
                    }

                    Out = result;
                    message = messageResult;

                    return dtResult;
                }
                catch (Exception ex)
                {
                    Out = -1;
                    message = ex.Message;

                    dtResult.Columns.Add("status");
                    dtResult.Columns.Add("message");
                    dtResult.Rows.Add(Out, message);
                    return dtResult;
                }
            }

        }

        public DataSet DataSetReader(SqlCommand command, out int Out, out string message)
        {
            using (DataSet dsResult = new DataSet())
            {
                try
                {
                    using (SqlDataAdapter reader =  new SqlDataAdapter(command))
                    {
                        reader.Fill(dsResult);
                    }
                    int result = -1;
                    string messageResult = "";

                    var paramlist = command.Parameters;

                    if (paramlist.Contains("@Out"))
                    {
                        result = (int)command.Parameters["@out"].Value;
                    }
                    if (paramlist.Contains("@message"))
                    {
                        messageResult = (string)command.Parameters["@message"].Value;
                    }

                    Out = result;
                    message = messageResult;

                    return dsResult;
                }
                catch (Exception ex)
                {
                    Out = -1;
                    message = ex.Message;

                    DataTable errorTable = new DataTable("Error");
                    errorTable.Columns.Add("status");
                    errorTable.Columns.Add("message");
                    errorTable.Rows.Add(Out, message);
                    dsResult.Tables.Add(errorTable);
                    return dsResult;
                }
            }

        }

        
    }
}
