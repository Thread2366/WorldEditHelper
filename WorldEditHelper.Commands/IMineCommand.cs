using System.Collections.Generic;

namespace WorldEditHelper.Commands
{
    public interface IMineCommand
    {
        IReadOnlyCollection<ICommandToken> Tokens { get; }

        TokenChoice GetTokenChoice();
        void PopToken();

        internal void AddToken(ICommandToken token);
    }
}
