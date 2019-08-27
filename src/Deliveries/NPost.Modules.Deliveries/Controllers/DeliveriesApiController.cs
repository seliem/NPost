using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPost.Modules.Deliveries.Shared.Commands;
using NPost.Shared;

namespace NPost.Modules.Deliveries.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveriesApiController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public DeliveriesApiController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        [HttpGet("_meta")]
        public ActionResult<string> Meta() => "Deliveries module";
        
        [HttpPost]
        public async Task<ActionResult> Post(StartDelivery command)
        {
            await _dispatcher.SendAsync(command);
            Response.Headers.Add("Resource-ID", $"{command.DeliveryId:N}");

            return Created($"parcels/{command.DeliveryId}", null);
        }
    }
}