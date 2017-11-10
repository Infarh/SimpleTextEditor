using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTextEditor
{
    class LamdaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> f_Execute;
        private readonly Func<object, bool> f_CanExecute;

        public LamdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            f_Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            f_CanExecute = CanExecute;
        }

        public void Execute(object parameter)
        {
            f_Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return f_CanExecute?.Invoke(parameter) ?? true;
        }
    }
}
