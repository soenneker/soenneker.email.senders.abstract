using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Email.Senders.Abstract.Tests;

[Collection("Collection")]
public sealed class IEmailSenderTests : FixturedUnitTest
{

    public IEmailSenderTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
