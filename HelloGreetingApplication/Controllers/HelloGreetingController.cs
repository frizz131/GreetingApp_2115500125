using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.DTO;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private static Dictionary<string, string> greetings = new Dictionary<string, string>();
        private readonly IGreetingBL _greetingBL;

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// Get method to get the greeting message
        /// </summary>
        /// <returns> "Hello World" </returns>
        [HttpGet]
        public IActionResult GetMethod()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting App Api endpoint.";
            responseModel.Data = "Hello World";
            return Ok(responseModel);
        }

        /// <summary>
        /// Post method to get the greeting message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns> response model</returns>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            if (requestModel == null || string.IsNullOrWhiteSpace(requestModel.Key) || string.IsNullOrWhiteSpace(requestModel.Value))
            {
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key and Value are required.",
                    Data = null
                });
            }

            if (greetings.ContainsKey(requestModel.Key))
            {
                return Conflict(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key already exists. Use a different key.",
                    Data = null
                });
            }

            greetings[requestModel.Key] = requestModel.Value;
            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting added successfully.",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <returns>Updated greeting message</returns>
        [HttpPut("{key}")]
        public IActionResult Put(string key, string newValue)
        {
            if (!greetings.ContainsKey(key))
            {
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found.",
                    Data = null
                });
            }

            greetings[key] = newValue;
            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting updated successfully.",
                Data = $"Key: {key}, Value: {newValue}"
            });

        }

        /// <summary>
        /// Delete method to remove a greeting message
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Deleted greeting message</returns>
        [HttpDelete]
        public IActionResult Delete(string key)
        {
            if (!greetings.ContainsKey(key))
            {
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found.",
                    Data = null
                });
            }

            string removedGreeting = greetings[key];
            greetings.Remove(key);
            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting deleted successfully.",
                Data = $"Key: {key}, Value: {removedGreeting}"
            });
        }

        [HttpPatch("{key}")]
        public IActionResult Patch(string key, string partialUpdate)
        {
            if (!greetings.ContainsKey(key))
            {
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found.",
                    Data = null
                });
            }

            greetings[key] += " " + partialUpdate;
            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting modified successfully.",
                Data = $"Key: {key}, Value: {greetings[key]}"
            });
        }

        [HttpGet("Greet")]
        public IActionResult GetGreeting()
        {
            var greetingMessage = _greetingBL.GetGreeting();
            var response = new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting retrieved successfully.",
                Data = greetingMessage
            };

            return Ok(response);
        }



        ///<summary>
        ///Post method to get a greeting using a request body
        ///</summary>
        [HttpPost("Personalized")]
        public IActionResult PostGreeting([FromBody] GreetingRequestModel requestModel)
        {
            var greetingMessage = _greetingBL.GetPersonalizedGreeting(requestModel);
            var response = new ResponseModel<string>
            {
                Success = true,
                Message = "Personalized greeting created successfully.",
                Data = greetingMessage
            };

            return Ok(response);
        }

        
        //[HttpPost("get-greeting")]
        //public IActionResult Post([FromBody] GreetingRequestModel requestModel)
        //{
        //    var greetingMessage = _greetingBL.GetPersonalizedGreeting(requestModel);
        //    var response = new ResponseModel<string>
        //    {
        //        Success = true,
        //        Message = "Personalized greeting created successfully.",
        //        Data = greetingMessage
        //    };

        //    return Ok(response);
        //}

        [HttpPost("Add-greet")]
        public IActionResult AddGreeting([FromBody] GreetingDTO greetingDTO)
        {
            bool isAdded = _greetingBL.AddGreeting(greetingDTO);
            if (isAdded)
            {
                return Ok(new { Success = true, Message = "Greeting Saved Successfully", Data = greetingDTO });
            }
            return BadRequest(new { Success = false, Message = "Failed to save greeting" });
        }

        [HttpGet("{id}")]
        public IActionResult GetGreetingById(int id)
        {
            var greeting = _greetingBL.GetGreetingById(id);
            if (greeting == null)
            {
                return NotFound(new { Success = false, Message = "Greeting Not Found!" });
            }
            return Ok(new { Success = true, Message = "Greeting Found", Data = greeting });
        }

    }
}
