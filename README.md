[![](https://img.shields.io/nuget/v/soenneker.canva.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.canva.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.canva.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.canva.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.canva.openapiclientutil/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Canva.OpenApiClientUtil
### A thread-safe utility for obtaining Canva's OpenApiClient singleton.

## Installation

```
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

The client sends the access token as `Authorization: Bearer <token>`.
