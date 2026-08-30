[![](https://img.shields.io/nuget/v/soenneker.email.senders.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.senders.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.senders.abstract/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.senders.abstract/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.senders.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.senders.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.senders.abstract/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.senders.abstract/actions/workflows/codeql.yml)

# Soenneker.Email.Senders.Abstract

Defines `IEmailSender`, the shared contract implemented by SMTP, Resend, and other email-delivery adapters.

## Install

```bash
dotnet add package Soenneker.Email.Senders.Abstract
```

## Send a structured message

```csharp
using Soenneker.Email.Senders.Abstract;
using Soenneker.Enums.Email.Format;
using Soenneker.Enums.Email.Priority;
using Soenneker.Messages.Email;

IEmailSender emailSender = /* resolve from DI */;

var message = new EmailMessage
{
    Type = "email.receipt.v1",
    Id = Guid.NewGuid().ToString("N"),
    Queue = "email",
    Sender = "orders-api",
    CreatedAt = DateTimeOffset.UtcNow,
    To = ["recipient@example.net"],
    Subject = "Your receipt",
    Format = EmailFormat.Html,
    Priority = EmailPriority.Normal,
    ContentFileName = "receipt.html"
};

bool sent = await emailSender.Send(message, cancellationToken);
```

## Send transport content

Consumers such as queue receptors can pass serialized `EmailMessage` content without deserializing it first:

```csharp
bool sent = await emailSender.Send(
    messageContent,
    transportType,
    cancellationToken);
```

`messageContent` is expected to contain a serialized `EmailMessage`. `transportType` is the message type identifier supplied by the transport; it is not necessarily a CLR type name, and each implementation decides whether to use it for routing or validation.

## Result contract

`true` means the implementation reports that it completed its delivery handoff. `false` means it deliberately did not send, commonly because delivery is disabled or a provider rejected the request. Rendering, configuration, serialization, transport, and provider failures may instead be raised as exceptions; consult the concrete sender's documentation.

Cancellation stops pending work when the implementation observes the token. It cannot recall a message already accepted by a delivery provider.
