
using BusinessService;
using Domain;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker_API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ResponseMessageModel objresponseMessageModel = new ResponseMessageModel();

        [HttpPost("register")]
        public ActionResult <ResponseMessageModel> CreateUser (UserRegisterModel Usermodel)
        {
            int Out = -1;
            string message = "";
            try
            {
                
                UserService objuserService = new UserService();

                if (Usermodel != null)
                {
                    objresponseMessageModel = objuserService.Createuser(Usermodel, out  Out, out  message);

                }
                else
                {
                    Out = -1;
                    message = "model Cannot be Null";
                }

                if (Out == 1)
                {
                    return Ok(objresponseMessageModel);
                }
                else if (Out == -99)
                {
                    return StatusCode(500, objresponseMessageModel);
                }
                else
                {
                    return StatusCode(422, objresponseMessageModel);
                }
            }
            catch (Exception ex) 
            {
                Out = -99;
                message = "DB error";

                return BadRequest(objresponseMessageModel);

            }
          

        }
    }
}
