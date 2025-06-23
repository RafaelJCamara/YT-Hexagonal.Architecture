namespace Core.UseCases.Common.Ports.Driving
{
    interface INullaryUseCase<TOutput>
    {
        Task<TOutput> ExecuteAsync();
    }

    interface IUnitUseCase<TInput>
    {
        Task ExecuteAsync(TInput input);
    }

    public interface IUseCase<TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
