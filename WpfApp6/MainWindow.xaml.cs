using ModernWpf.Controls;
using ModernWpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfApp6.Pages;
using ModernWpf.Media.Animation;
using System.ComponentModel;
using System;
using System.Net;
//using WpfApp6.Services;

namespace WpfApp6
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Home home;
        private Settings settings;
        private UIElement about;
        private string _discordUsername;
        private string _discordAvatar;
        private object response;
        private const string DiscordClientId = "1225746906844631072";

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            // Initialize home and settings pages
            home = new Home();
            settings = new Settings();
           

        }

        // Method to fetch Discord profile information
        

        // Add properties for Discord account information
        public string DiscordUsername
        {
            get { return _discordUsername; }
            set
            {
                _discordUsername = value;
                OnPropertyChanged(nameof(DiscordUsername));
            }
        }

        public string DiscordAvatar
        {
            get { return _discordAvatar; }
            set
            {
                _discordAvatar = value;
                OnPropertyChanged(nameof(DiscordAvatar));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Home page
            ContentFrame.Child = home;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Settings page
            ContentFrame.Child = settings;
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the click event for the AboutButton here
            // For example, you can display a message box with information about the application
            ContentFrame.Child = about;
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Navigate to the home page when the navigation view is loaded
            ContentFrame.Child = home;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // Navigate to the settings page when the settings item is selected
                ContentFrame.Child = settings;
            }
            else
            {
                NavigationViewItem? item = args.SelectedItem as NavigationViewItem;

                if (item.Tag.ToString() == "Home")
                {
                    // Navigate to the home page when the home item is selected
                    ContentFrame.Child = home;
                }
            }
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            // Handle navigation failure
            throw new Exception("Failed to load Page.");
        }
    }
}