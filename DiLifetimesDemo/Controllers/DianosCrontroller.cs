using Microsoft.AspNetCore.Mvc;
using DiLifetimesDemo.Services;
namespace DiLifetimesDemo.Controllers
{
    [ApiController]
    [Route("api/diagnostics")]
    public class DianosCrontroller : ControllerBase
    {
        private readonly TransientServices _transient1;
        private readonly TransientServices _transient2;
        private readonly ScopedServices _scoped1;
        private readonly ScopedServices _scoped2;
        private readonly SingletonServices _singleton1;
        private readonly SingletonServices _singleton2;

        public DianosCrontroller(
            TransientServices transient1,
            TransientServices transient2,
            ScopedServices scoped1,
            ScopedServices scoped2,
            SingletonServices singleton1,
            SingletonServices singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }
        [HttpGet("lifetimes")]
        public IActionResult GetLifetimes()
        {
            return Ok(new
            {
                Transient1 = _transient1.Id,
                Transient2 = _transient2.Id,
                Scoped1 = _scoped1.Id,
                Scoped2 = _scoped2.Id,
                Singleton1 = _singleton1.Id,
                Singleton2 = _singleton2.Id
            });
        }
    }
}
