using Microsoft.AspNetCore.Mvc;
using DiLifetimesDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiLifetimesDemo.Controllers
{
    [ApiController]
    [Route("api/scoped")]
    public class ScopedController : ControllerBase
    {
        private readonly ScopedServices _scopedFromRequest;
        public ScopedController(ScopedServices scopedFromRequest)
        {
            _scopedFromRequest = scopedFromRequest;
        }
        [HttpGet("compare")]
        public IActionResult CompareScopes([FromServices] IServiceProvider serviceProvider)
        {
            var scopedRequest = _scopedFromRequest.Id;
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedManual = scope.ServiceProvider.GetRequiredService<ScopedServices>().Id;
                return Ok(new 
                {
                    ScopedFromRequest = scopedRequest,
                    ScopedFromManualScope = scopedManual
                });
            }
        }
    }
}
    
