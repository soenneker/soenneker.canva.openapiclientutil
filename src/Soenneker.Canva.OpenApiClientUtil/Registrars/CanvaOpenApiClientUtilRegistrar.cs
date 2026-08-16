using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Canva.HttpClients.Registrars;
using Soenneker.Canva.OpenApiClientUtil.Abstract;

namespace Soenneker.Canva.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CanvaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CanvaOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCanvaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCanvaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICanvaOpenApiClientUtil, CanvaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CanvaOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCanvaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCanvaOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICanvaOpenApiClientUtil, CanvaOpenApiClientUtil>();

        return services;
    }
}
