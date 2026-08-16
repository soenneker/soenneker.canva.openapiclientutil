using Soenneker.Canva.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Canva.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CanvaOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICanvaOpenApiClientUtil _openapiclientutil;

    public CanvaOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICanvaOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
