using Domain;
using Domain.User;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq.Expressions;


namespace BusinessService
{
    public class UserService

    {

        UserSQL ObjUsersql = new UserSQL();
        ResponseMessageModel ObjresponseMessageModel = new ResponseMessageModel();
        BusinessHelper objbusinessHelper = new BusinessHelper();
        public ResponseMessageModel Createuser(UserRegisterModel UserModel, out int Out, out string message)
        {
            try
            {
                if (UserModel != null)
                {
                    DataTable result = ObjUsersql.CreateUser(UserModel, out Out, out message);

                    ObjresponseMessageModel = objbusinessHelper.ResponseDataTableMessage(result, Out, message);

                }
                else
                {
                    Out = -1;
                    message = "User model is null.";
                    ObjresponseMessageModel.Out = Out;
                    ObjresponseMessageModel.Message = message;
                    ObjresponseMessageModel.ErrorMessage = "Invalid input.";
                }

            }
            catch (Exception ex)
            {
                Out = -1;
                message = ex.Message;

                ObjresponseMessageModel.Out = Out;
                ObjresponseMessageModel.Message = "An exception occurred.";
                ObjresponseMessageModel.ErrorMessage = ex.Message;
            }
            return ObjresponseMessageModel;
        }

    }

}
