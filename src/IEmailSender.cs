using Soenneker.Messages.Email;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Email.Senders.Abstract;

/// <summary>
/// Interface for sending emails based on a raw service bus message content and its associated type.
/// Wraps logic for rendering templates, transforming content.
/// </summary>
public interface IEmailSender
{
    /// <summary>
    /// Sends an email using the given raw message content and type.
    /// </summary>
    /// <param name="messageContent">
    /// The JSON string content of the message. Expected to deserialize into an <see cref="Soenneker.Messages.Email.EmailMessage"/>.
    /// </param>
    /// <param name="type">
    /// The target CLR type to deserialize the message content into. Typically <see cref="Soenneker.Messages.Email.EmailMessage"/>.
    /// </param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation, with a boolean indicating whether sending was successful.
    /// </returns>
    Task<bool> Send(string messageContent, string type, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends the specified email message asynchronously.
    /// </summary>
    /// <param name="message">The email message to send. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the send operation.</param>
    /// <returns>A task that represents the asynchronous send operation. The task result is <see langword="true"/> if the message
    /// was sent successfully; otherwise, <see langword="false"/>.</returns>
    Task<bool> Send(EmailMessage message, CancellationToken cancellationToken = default);
}