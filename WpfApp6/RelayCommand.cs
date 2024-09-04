using System;
using System.Windows.Input;

namespace WpfApp6
{
    internal class RelayCommand : ICommand
    {
        public RelayCommand(Action<object, ExecutedRoutedEventArgs> openDiscordLink)
        {
            OpenDiscordLink = openDiscordLink;
        }

        public Action<object, ExecutedRoutedEventArgs> OpenDiscordLink { get; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}