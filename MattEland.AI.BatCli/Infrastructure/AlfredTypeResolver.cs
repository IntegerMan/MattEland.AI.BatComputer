using Spectre.Console.Cli;

namespace MattEland.AI.BatCli.Infrastructure;

public sealed class AlfredTypeResolver(IServiceProvider provider) : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider = provider ?? throw new ArgumentNullException(nameof(provider));

    public object? Resolve(Type? type)
    {
        if (type == null)
        {
            return null;
        }

        return _provider.GetService(type);
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
