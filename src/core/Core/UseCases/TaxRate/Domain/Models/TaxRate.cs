namespace Core.UseCases.TaxRate.Domain.Models;

public class TaxRate
{
    public Guid Id { get; set; }
    public Continent Continent { get; set; }
    public double Rate { get; set; }

    public double ComputeTaxRate()
    {
        var currentDayOfTheWeek = (int)DateTime.UtcNow.DayOfWeek;

        return Rate * (1 + currentDayOfTheWeek / 7);
    }
}
