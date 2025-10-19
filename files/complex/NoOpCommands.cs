using System;

namespace Complex
{
    /// <summary>
    /// A "do nothing" command for empty slots.
    /// Prevents null checks everywhere.
    /// </summary>
    public sealed class NoOpCommand : ICommand
    {
        public void Execute() => Console.WriteLine("(No command assigned)");
        public void Undo() { /* nothing to undo */ }
    }
}
