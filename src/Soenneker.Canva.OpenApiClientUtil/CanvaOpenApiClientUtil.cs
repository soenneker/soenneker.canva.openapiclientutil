using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Canva.HttpClients.Abstract;
using Soenneker.Canva.OpenApiClientUtil.Abstract;
using Soenneker.Canva.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Canva.OpenApiClientUtil;

///<inheritdoc cref="ICanvaOpenApiClientUtil"/>
public sealed class CanvaOpenApiClientUtil : ICanvaOpenApiClientUtil
{
    private readonly AsyncSingleton<CanvaOpenApiClient> _client;

    public CanvaOpenApiClientUtil(ICanvaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CanvaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Canva:AccessToken");
            string authHeaderName = configuration["Canva:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Canva:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new CanvaOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CanvaOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
