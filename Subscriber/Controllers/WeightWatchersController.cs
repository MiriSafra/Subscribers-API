using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;

namespace Subscriber.WebWpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightWatchersController : ControllerBase
    {
        IWeightWatchersService _weightWatchersService;

        public WeightWatchersController(IWeightWatchersService weightWatchersService)
        {
            _weightWatchersService = weightWatchersService;
        }
        [HttpPost]
        public async Task<ActionResult<Generalresponse<bool>> >Register([FromBody] SubscriberDTO subscriberDTO,double height)
        {
            var response= await _weightWatchersService.Register(subscriberDTO,height);
            if (response.Succeeded == false)
            {
                return NotFound(response);
            }
            return Ok(response);
          
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Generalresponse<CardDTO>>> Login([FromBody] LoginModel loginModel)
        {
            var response = await _weightWatchersService.Login(loginModel.Password, loginModel.Email);
            if (response.Succeeded == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Generalresponse<ResponseGetCard_ID>>> GetCardById( int id)
        {
            var response = await _weightWatchersService.GetCardDetails(id);
            if (response.Succeeded == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
         
    }
}
