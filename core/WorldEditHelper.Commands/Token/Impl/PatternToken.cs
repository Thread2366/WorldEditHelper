namespace WorldEditHelper.Commands.Token.Impl;

public class PatternToken : WeTokenBase
{
    public PatternToken(int index, TokenState state) : base(index, state) { }

    public string Value { get; set; } = string.Empty;

    public override string Render()
    {
        return Value;
    }
}
