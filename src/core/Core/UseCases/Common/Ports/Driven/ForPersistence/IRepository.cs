namespace Core.UseCases.Common.Ports.Driven.ForPersistence;

public interface IRepository<T>
{
    Task<T?> GetSingleByAsync(Func<T, bool> predicate);
}
