using Microsoft.AspNetCore.Mvc;
using DiLifetimesDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiLifetimesDemo.Controllers
{
    [ApiController]
    [Route("api/singleton")]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonServices _singleton;
        public SingletonController(SingletonServices singleton)
        {
            _singleton = singleton;
        }
        [HttpGet("safe-scoped")]
        public IActionResult GetSafeScoped([FromServices] IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scoped = scope.ServiceProvider.GetRequiredService<ScopedServices>();
                return Ok(new  
                {
                    SingletonId = _singleton.Id,
                    ScopedIdFromTempScope = scoped.Id
                });
            }
        }
    }
}
