using WorldEditHelper.Commands.Token;

namespace WorldEditHelper.Commands.Command;

public interface IWeCommand
{
    string Name { get; }

    IReadOnlyCollection<IWeToken> Tokens { get; }

    string Render();
}
