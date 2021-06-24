using System;
using System.Windows.Input;

namespace AlgoProject.ViewModel
{
    public class CommandBase : ICommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> onExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>Сommand constructor.</summary>
        /// <param name="execute">Executable command method.</param>
        /// <param name="canExecute">Method allowing command execution.</param>
        public CommandBase(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.onExecute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>Calling the resolving method of the command.</summary>
        /// <param name="parameter">Command parameter.</param>
        /// <returns>True? if command execution is allowed.</returns>
        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute.Invoke(parameter);

        /// <summary>Calling the executing method of the command.</summary>
        /// <param name="parameter">Command parameter.</param>
        public void Execute(object parameter) => onExecute?.Invoke(parameter);
    }
}
