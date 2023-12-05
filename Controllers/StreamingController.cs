using Microsoft.AspNetCore.Mvc;


namespace SS.Controller{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController:ControllerBase{

        [HttpGet]
        public IActionResult Get(){
            var response = new {
                Version = HttpContext.GetRequestedApiVersion().ToString(),
                Value = "Hello from version 1"
            };
            return Ok(response);
        }



    }

    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class Streaming2Controller:ControllerBase{
        [HttpGet]
        public IActionResult Get(){
            var response = new {
                Version = HttpContext.GetRequestedApiVersion().ToString(),
                Value = "Hello from version 2"
            };
            return Ok(response);
        }
    }

}

