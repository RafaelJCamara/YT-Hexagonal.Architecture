using Core.UseCases.Common.Ports.Driven.ForNotification;
using System.Text.Json;

namespace RabbitMqAdapter
{
    public class RabbitMqNotification : INotification
    {
        public Task<bool> NotifyAsync<T>(T content)
        {
            Console.WriteLine($"Sending this notification from RabbitMQ: {JsonSerializer.Serialize(content)}");

            return Task.FromResult(true);
        }
    }
}
