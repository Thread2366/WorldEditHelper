namespace WorldEditHelper.Commands
{
    public interface ICommandToken
    {
        string Description { get; }

        string Render();
    }
}
