namespace WorldEditHelper.Commands.Token;

public abstract class WeTokenBase : IWeToken
{
    public int Index { get; }

    public TokenState State { get; set; }

    protected WeTokenBase(int index, TokenState state)
    {
        Index = index;
        State = state;
    }

    public abstract string Render();
}
