using System;
using System.Collections.Generic;

namespace Simple
{
    /// <summary>
    /// Invoker: presses commands and keeps history for Undo/Redo.
    /// </summary>
    public class RemoteControl
    {
        private readonly Stack<ICommand> _undo = new();
        private readonly Stack<ICommand> _redo = new();

        /// <summary>Press a command and record it in history.</summary>
        public void Press(ICommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Console.WriteLine($"> {command.Name}");
            command.Execute();

            _undo.Push(command);
            _redo.Clear(); // new action wipes redo history
        }

        /// <summary>Undo the most recent command.</summary>
        public void Undo()
        {
            if (_undo.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return;
            }

            var last = _undo.Pop();
            Console.WriteLine($"< UNDO {last.Name}");
            last.Undo();
            _redo.Push(last);
        }

        /// <summary>Redo the last undone command.</summary>
        public void Redo()
        {
            if (_redo.Count == 0)
            {
                Console.WriteLine("Nothing to redo.");
                return;
            }

            var cmd = _redo.Pop();
            Console.WriteLine($"> REDO {cmd.Name}");
            cmd.Execute();
            _undo.Push(cmd);
        }
    }
}
