using System;
using System.Collections.Generic;

namespace WorldEditHelper.Commands
{
    public class TokenChoice : IDisposable
    {
        private readonly IMineCommand _command;

        public IReadOnlyCollection<ICommandToken> Options { get; }

        public ICommandToken Selected { get; set; }

        public void Dispose()
        {
            if (Selected != null)
                _command.AddToken(Selected);
        }
    }
}
