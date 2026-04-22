using Soenneker.Tests.HostedUnit;

namespace Soenneker.Email.Senders.Abstract.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class IEmailSenderTests : HostedUnitTest
{

    public IEmailSenderTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
