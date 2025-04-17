using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace MattEland.AI.BatCli.Infrastructure;

public sealed class AlfredTypeRegistrar(IServiceCollection builder) : ITypeRegistrar
{
    public ITypeResolver Build() => new AlfredTypeResolver(builder.BuildServiceProvider());

    public void Register(Type service, Type implementation) => builder.AddSingleton(service, implementation);

    public void RegisterInstance(Type service, object implementation) => builder.AddSingleton(service, implementation);

    public void RegisterLazy(Type service, Func<object> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        builder.AddSingleton(service, _ => func());
    }
}
