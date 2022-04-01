using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallWebAPI.Model;
using CallWebBackend.Common;
using CallWebBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallWebAPI.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("getActiveUsers")]
        public IActionResult GetActiveUsers()
        {
            ResultLog result = UserService.GetInstance().GetActiveUsers();

            return Ok(new ApiBaseModel()
            {
                Success = result.IsSuccess(),
                Data = result.ReturnObject,
                Message = result.Message
            });
        }
    }
}
