using Core.UseCases.Common.Ports.Driven.ForNotification;
using Core.UseCases.Common.Ports.Driven.ForPersistence;
using MongoDbAdapter;
using RabbitMqAdapter;

var apiAdapter = new ApiAdapter(args, options =>
{
    options.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryAdapter<>));
    options.AddTransient<INotification, RabbitMqNotification>();
});