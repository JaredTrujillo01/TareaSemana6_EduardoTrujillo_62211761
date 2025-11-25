using System;
namespace DiLifetimesDemo.Services
{
    public class SingletonServices
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
