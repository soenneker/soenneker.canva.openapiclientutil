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
    ValueTask<CanvaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
