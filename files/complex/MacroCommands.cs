using System;
using System.Collections.Generic;

namespace Complex
{
    /// <summary>
    /// Composite command — runs multiple commands as a group.
    /// </summary>
    public sealed class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public MacroCommand(IEnumerable<ICommand> commands)
        {
            _commands = new List<ICommand>(commands);
        }

        public void Execute()
        {
            foreach (var cmd in _commands)
                cmd.Execute();
        }

        public void Undo()
        {
            for (int i = _commands.Count - 1; i >= 0; i--)
                _commands[i].Undo();
        }
    }
}
