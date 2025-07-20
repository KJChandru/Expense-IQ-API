using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class BusinessHelper
    {
        public ResponseMessageModel ResponseDataTableMessage(DataTable data,int Out , string Message)
        {
            ResponseMessageModel objResponseMessageModel = new ResponseMessageModel();

            if (Out == 1)
            {
                objResponseMessageModel.Out = Out;
                objResponseMessageModel.Data = data;
                objResponseMessageModel.Message = Message;
            }

            if (Out == -1)
            {
                objResponseMessageModel.Out = Out;
                objResponseMessageModel.Data = data;
                objResponseMessageModel.Message = Message;
            }

            return objResponseMessageModel;
        }
    }
}
