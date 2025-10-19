using System;
using System.Collections.Generic;

namespace Complex
{
    /// <summary>
    /// Invoker for the Command pattern.
    /// - Keeps a small list of "slots" (buttons).
    /// - Each slot holds a command.
    /// - PressButton(i) runs whatever command is in slot i.
    /// No undo/redo here; your buttons implement toggle behavior themselves
    /// by choosing the right command based on current device state.
    /// </summary>
    public class RemoteControl
    {
        private readonly List<ICommand> _slots = new();

        /// <summary>
        /// Create a remote with a fixed number of slots.
        /// Empty slots are filled with NoOpCommand so calls are always safe.
        /// </summary>
        public RemoteControl(int slotCount = 5)
        {
            if (slotCount < 1) slotCount = 1;
            for (int i = 0; i < slotCount; i++)
                _slots.Add(new NoOpCommand());
        }

        /// <summary>
        /// Assign a command to a slot (button).
        /// </summary>
        public void SetCommand(int slot, ICommand command)
        {
            if (!IsValidSlot(slot))
            {
                Console.WriteLine("Invalid slot.");
                return;
            }

            if (command != null)
            {
                _slots[slot] = command;
            }       
            else
            {
                _slots[slot] = new NoOpCommand();
            }
        }

        /// <summary>
        /// Simulate pressing a button: execute the command in that slot.
        /// </summary>
        public void PressButton(int slot)
        {
            if (!IsValidSlot(slot))
            {
                Console.WriteLine("Invalid slot.");
                return;
            }

            _slots[slot].Execute();
        }

        /// <summary>
        /// Optional helper: run any ad-hoc command immediately (not stored).
        /// </summary>
        public void Press(ICommand command)
        {
            if (command != null)
            {
                command.Execute();
            }
            else
            {
                var noCommand = new NoOpCommand();
                noCommand.Execute();
            }
        }

        private bool IsValidSlot(int slot) => slot >= 0 && slot < _slots.Count;
    }
}
