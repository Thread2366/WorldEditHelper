using System.Reflection;
using WorldEditHelper.Commands.Command;
using WorldEditHelper.Commands.Token;

namespace WorldEditHelper.Commands;

public abstract class WeCommandBase : IWeCommand
{
    public abstract string Name { get; }

    public IReadOnlyCollection<IWeToken> Tokens => _tokens ??= GetType()
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.PropertyType == typeof(IWeToken))
        .Select(p => p.GetValue(this))
        .Where(val => val != null)
        .Cast<IWeToken>()
        .OrderBy(token => token.Index)
        .ToArray();

    private IReadOnlyCollection<IWeToken>? _tokens;

    public string Render()
    {
        return string.Join(" ", Tokens
            .Where(token => token.State != TokenState.Disabled)
            .Select(token => token.Render())
            .Prepend(Name));
    }
}
