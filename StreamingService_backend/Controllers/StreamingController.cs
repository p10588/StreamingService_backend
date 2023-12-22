using Microsoft.AspNetCore.Mvc;
using SS.Service;


namespace SS.Controller{

    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController:ControllerBase{
        
        private StreamingService _service;

        public StreamingController(StreamingService service){
            Console.WriteLine("Start Controller");
            this._service = service;
        }

        [HttpGet("test")]
        public IActionResult Get(){
            var response = new {
                Version = HttpContext.GetRequestedApiVersion().ToString(),
                Value = "Hello from version 1"
            };
            return Ok(response);
        }

        public IActionResult GetAllStreamingContent(){
            return null;
        }
    }

    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class Streaming2Controller:ControllerBase{
        [HttpGet("test")]
        public IActionResult Get(){
            var response = new {
                Version = HttpContext.GetRequestedApiVersion().ToString(),
                Value = "Hello from version 2"
            };
            return Ok(response);
        }
    }

}

