using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallWebAPI.Model;
using CallWebBackend.Common;
using CallWebBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CallWebAPI.Controllers
{

    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("getProducts")]
        public IActionResult GetProducts()
        {
            ResultLog result = ProductService.GetInstance().GetProducts();

            return Ok(new ApiBaseModel()
            {
                Success = result.IsSuccess(),
                Data = result.ReturnObject,
                Message = result.Message
            });
        }
    }
}
