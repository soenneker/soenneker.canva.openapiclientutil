using Soenneker.Canva.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Canva.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICanvaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Canva client for the current utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the client.</returns>
    ValueTask<CanvaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
