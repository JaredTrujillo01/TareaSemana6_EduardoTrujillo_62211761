using System;
namespace DiLifetimesDemo.Services
{
    public class ScopedServices
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
