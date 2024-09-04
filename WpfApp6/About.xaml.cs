using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp6
{
    // Ensure both parts of the partial class have the same access level modifier
     partial class About
    {
        public static ICommand OpenDiscordCommand { get; } = new RelayCommand(OpenDiscordLink);

        public About()
        {
        }

        public static UIElement CreateAboutPage(CommandBinding commandBinding)
        {
            // Create a Grid to hold the contents of the About page
            Grid grid = new Grid();

            // Set the visibility property of the grid
            grid.Visibility = Visibility.Collapsed;

            // Create a StackPanel to hold the text elements
            StackPanel stackPanel = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Create a TextBlock for the main text
            TextBlock mainText = new TextBlock
            {
                Text = "This is the official frost launcher, We are hosting chapter 2 season 4. Join the discord",
                Margin = new Thickness(0, 0, 0, 10)
            };

            // Create a TextBlock for the Discord link
            TextBlock discordLink = new TextBlock
            {
                Text = "https://discord.gg/jfaSP9dQYc",
                FontWeight = FontWeights.Bold,
                Foreground = System.Windows.Media.Brushes.Blue,
                TextDecorations = TextDecorations.Underline,
                Margin = new Thickness(0, 10, 0, 0),
                Cursor = Cursors.Hand,
            };

            // Add the command binding to handle the command
            discordLink.CommandBindings.Add(commandBinding);

            // Add the text blocks to the stack panel
            stackPanel.Children.Add(mainText);
            stackPanel.Children.Add(discordLink);

            // Add the stack panel to the grid
            grid.Children.Add(stackPanel);

            // Return the grid as the UI element for the About page
            return grid;
        }

        // Command handler for opening the Discord link
        private static void OpenDiscordLink(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start("https://discord.gg/jfaSP9dQYc");
        }
    }
}