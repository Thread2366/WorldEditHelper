namespace WorldEditHelper.Commands.Token;

public interface IWeToken
{
    int Index { get; }

    TokenState State { get; set; }

    string Render();
}
