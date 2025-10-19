using System;

namespace Complex
{
    /// <summary>
    /// Command interface for executing and undoing actions.
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
