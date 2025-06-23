using Core.UseCases.TaxRate.ComputeTaxRate;
using Core.UseCases.TaxRate.ComputeTaxRate.Ports.Driver;
using Core.UseCases.TaxRate.Domain.Models;

public class ApiAdapter
{
    public ApiAdapter(string[] args, Action<IServiceCollection> options)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<IComputeTaxRateUseCase, ComputeTaxRateUseCaseUseCase>();

        options(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/api/tax-rate", async (IComputeTaxRateUseCase computeTaxRateUseCase, string continent) =>
        {
            var cont = (Continent)Enum.Parse(typeof(Continent), continent, true);

            return Results.Ok(await computeTaxRateUseCase.ExecuteAsync(cont));
        });

        app.Run();
    }
}


