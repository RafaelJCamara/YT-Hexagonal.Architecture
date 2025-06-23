namespace Core.UseCases.Common.Ports.Driven.ForNotification;

public interface INotification
{
    Task<bool> NotifyAsync<T>(T content);
}
