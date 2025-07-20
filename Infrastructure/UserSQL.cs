using Domain.User;
using Infrastructure.SqlHelper;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml;

namespace Infrastructure
{
    public class UserSQL :SqlHelperExecute
    {
        public DataTable  CreateUser(UserRegisterModel Usermodel,out int Out,out string message)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection("abc"))
                {
                    using (SqlCommand command = new SqlCommand("spnaame", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", Usermodel.Id);
                        command.Parameters.AddWithValue("@FirstName", Usermodel.FirstName);
                        command.Parameters.AddWithValue("@LastName", Usermodel.LastName);
                        command.Parameters.AddWithValue("@username", Usermodel.UserName);
                        command.Parameters.AddWithValue("@password", Usermodel.Password);
                        command.Parameters.AddWithValue("@Out",-1).Direction = ParameterDirection.Output;

                        SqlParameter Message = new SqlParameter();
                        Message.Direction=ParameterDirection.Output;
                        Message.Size = 50;
                        command.Parameters.Add(Message);

                        connection.Open();

                        return  DataTableReader(command, out Out, out message);
                    }
                }
            }
            catch (Exception ex)
            {
                Out = -1;
                message = ex.Message;

                result.Columns.Add("status");
                result.Columns.Add("message");
                result.Rows.Add(Out, message);

                return result;  

            }
        }
    }
}
