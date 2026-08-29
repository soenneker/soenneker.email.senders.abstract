[![](https://img.shields.io/nuget/v/soenneker.email.senders.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.senders.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.senders.abstract/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.email.senders.abstract/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.email.senders.abstract.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.email.senders.abstract/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.email.senders.abstract/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.email.senders.abstract/actions/workflows/codeql.yml)

# Soenneker.Email.Senders.Abstract

Interface for sending emails based on a raw service bus message content and its associated type. Wraps logic for rendering templates, transforming content.

## Install

```bash
dotnet add package Soenneker.Email.Senders.Abstract
```

## Quick start

```csharp
using Soenneker.Email.Senders.Abstract;

IEmailSender emailSender = /* resolve from DI */;
var result = await emailSender.Send("value", "value", default);
```

Sends an email using the given raw message content and type.

## What you get

- `IEmailSender` — Interface for sending emails based on a raw service bus message content and its associated type. Wraps logic for rendering templates, transforming content.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IEmailSender.Send(messageContent, type, cancellationToken)` | Sends an email using the given raw message content and type. | A task representing the asynchronous operation, with a boolean indicating whether sending was successful. |
| `IEmailSender.Send(message, cancellationToken)` | Sends the specified email message asynchronously. | A task that represents the asynchronous send operation. The task result is `true` if the message was sent successfully; otherwise, `false`. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
