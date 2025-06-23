using Core.UseCases.Common.Ports.Driven.ForNotification;
using Core.UseCases.Common.Ports.Driven.ForPersistence;
using Core.UseCases.TaxRate.ComputeTaxRate.Ports.Driver;
using Core.UseCases.TaxRate.Domain.Exceptions;
using Core.UseCases.TaxRate.Domain.Models;

namespace Core.UseCases.TaxRate.ComputeTaxRate;

public class ComputeTaxRateUseCaseUseCase(IRepository<Domain.Models.TaxRate> repository, INotification notification) : IComputeTaxRateUseCase
{
    public async Task<double> ExecuteAsync(Continent continent)
    {
        var taxRateForContinent = await repository.GetSingleByAsync(x => x.Continent == continent);

        if (taxRateForContinent is null)
        {
            throw new NoTaxRateForContinentException(continent);
        }

        var taxRate = taxRateForContinent.ComputeTaxRate();

        await notification.NotifyAsync(new
        {
            Title = "Tax Rate Computation",
            Message = $"Computed tax rate for {continent} is {taxRate}",
            Timestamp = DateTime.UtcNow
        });

        return taxRate;
    }
}
