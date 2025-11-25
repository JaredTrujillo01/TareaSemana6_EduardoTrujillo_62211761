using System;
namespace DiLifetimesDemo.Services
{
    public class TransientServices
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
