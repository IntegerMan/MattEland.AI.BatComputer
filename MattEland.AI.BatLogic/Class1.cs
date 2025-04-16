using Microsoft.Extensions.AI;

namespace MattEland.AI.BatLogic;

public class EchoChatClient : IChatClient
{
    public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null,
        CancellationToken cancellationToken = new())
    {
        IEnumerable<ChatMessage> responseMessages = messages.Select(m =>
        {
            List<AIContent> responses = m.Contents.ToList();
            return new ChatMessage(ChatRole.System, responses);
        });

        return Task.FromResult(new ChatResponse(responseMessages.ToList()));
    }

    public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public object? GetService(Type serviceType, object? serviceKey = null)
    {
        if (serviceType == typeof(IChatClient))
        {
            return this;
        }

        return null;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
