using Core.UseCases.TaxRate.Domain.Models;

namespace Core.UseCases.TaxRate.Domain.Exceptions
{
    public class NoTaxRateForContinentException : Exception
    {
        public NoTaxRateForContinentException(Continent continent)
            : base($"No tax rate found for continent: {continent.ToString()}")
        {
        }
        public NoTaxRateForContinentException(Continent continent, Exception innerException)
            : base($"No tax rate found for continent: {continent.ToString()}", innerException)
        {
        }
    }
}
