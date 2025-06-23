using Core.UseCases.Common.Ports.Driven.ForPersistence;
using Core.UseCases.TaxRate.Domain.Models;

namespace MongoDbAdapter
{
    public class MongoRepositoryAdapter<T> : IRepository<T>
    {
        //inject mongo db context or client here

        public Task<T?> GetSingleByAsync(Func<T, bool> predicate)
        {
            Console.WriteLine("*** Mongo Adapter - Database query");
            return Task.FromResult(Collections.GetCollectionOfType<T>().FirstOrDefault(predicate));
        }
    }

    public static class Collections
    {
        private static List<TaxRate> _collection = [
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.Europe, Rate = 0.20 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.Africa, Rate = 0.15 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.Asia, Rate = 0.18 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.NorthAmerica, Rate = 0.22 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.SouthAmerica, Rate = 0.19 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.Oceania, Rate = 0.25 },
            new TaxRate { Id = Guid.NewGuid(), Continent = Continent.Antarctica, Rate = 0.10 }
        ];

        public static List<T> GetCollectionOfType<T>()
        {
            if (typeof(T) == typeof(TaxRate))
            {
                return _collection as List<T>;
            }
            throw new InvalidOperationException($"No collection found for type {typeof(T).Name}");
        }

    }

}
