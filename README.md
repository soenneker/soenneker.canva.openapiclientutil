[![](https://img.shields.io/nuget/v/soenneker.canva.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.canva.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.canva.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.canva.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.canva.openapiclientutil/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.canva.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.openapiclientutil/)

# Soenneker.Canva.OpenApiClientUtil

Provides a lazily created Canva Connect API client backed by the configured cached `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Canva.OpenApiClientUtil
```

## Configuration

```json
{
  "Canva": {
    "AccessToken": "your-oauth-access-token"
  }
}
```

The client sends the access token as `Authorization: Bearer <token>`. A compatible gateway can be configured with `Canva:ClientBaseUrl`, `Canva:AuthHeaderName`, and `Canva:AuthHeaderValueTemplate`.

## Registration and usage

```csharp
using Soenneker.Canva.OpenApiClient;
using Soenneker.Canva.OpenApiClient.Models;
using Soenneker.Canva.OpenApiClientUtil.Abstract;
using Soenneker.Canva.OpenApiClientUtil.Registrars;

services.AddCanvaOpenApiClientUtilAsScoped();

public sealed class CanvaService(ICanvaOpenApiClientUtil clientUtil)
{
    public async Task<UsersMeResponse?> GetCurrentUser(CancellationToken cancellationToken)
    {
        CanvaOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.V1.Users.Me.GetAsync(cancellationToken: cancellationToken);
    }
}
```

The scoped utility releases its own generated client holder with the consuming scope. Its registered HTTP provider is singleton and remains available until application shutdown. Singleton utility registration is also available.
