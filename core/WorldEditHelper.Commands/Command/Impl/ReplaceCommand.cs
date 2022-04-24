using WorldEditHelper.Commands.Token;
using WorldEditHelper.Commands.Token.Impl;

namespace WorldEditHelper.Commands.Command.Impl;

public class ReplaceCommand : WeCommandBase
{
    public override string Name => "//replace";

    public MaskToken Mask { get; } = new(0, TokenState.Required);

    public PatternToken Pattern { get; } = new(1, TokenState.Required);
}
