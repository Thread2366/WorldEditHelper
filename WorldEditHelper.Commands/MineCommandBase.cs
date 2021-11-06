using System.Collections.Generic;

namespace WorldEditHelper.Commands
{
    internal abstract class MineCommandBase : IMineCommand
    {
        protected readonly Stack<ICommandToken> TokensStack;

        internal MineCommandBase(IEnumerable<ICommandToken> tokens)
        {
            TokensStack = new Stack<ICommandToken>(tokens);
        }

        public IReadOnlyCollection<ICommandToken> Tokens => TokensStack;

        public abstract TokenChoice GetTokenChoice();

        public void PopToken()  
        {
            TokensStack.Pop();
        }

        void IMineCommand.AddToken(ICommandToken token)
        {
            TokensStack.Push(token);
        }
    }
}
