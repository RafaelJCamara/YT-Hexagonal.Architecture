using Core.UseCases.Common.Ports.Driving;
using Core.UseCases.TaxRate.Domain.Models;

namespace Core.UseCases.TaxRate.ComputeTaxRate.Ports.Driver;

public interface IComputeTaxRateUseCase : IUseCase<Continent, double>
{
}