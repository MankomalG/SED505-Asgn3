using System;

namespace Simple
{
    /// <summary>
    /// The command interface. Every command can run (Execute) and be reversed (Undo).
    /// </summary>
    public interface ICommand
    {
        void Execute();       // Perform the action
        void Undo();          // Reverse the action
        string Name { get; }  // Short name for logs
    }
}
