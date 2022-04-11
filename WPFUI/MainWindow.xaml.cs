using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();

            /* instantiates everything in GameSession
             * this includes instantiation of values in player class CurrentPlayer
             */

            _gameSession = new GameSession();

            // Add OnGameMessageRaised to the event OnMessageRaised
            _gameSession.OnMessageRaised += OnGameMessageRaised;

            // DataContext is built-in; XAML file will use the object in the UI
            DataContext = _gameSession;
        }

        private void OnGameMessageRaised(object sender, Engine.EventArgs.GameMessageEventArgs e)
        {
            // in MainWindow.xaml, add a new Block with the message tagged as GameMessages (found in .xaml file)
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }

        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }
        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }

        /*
        // used for button test in MainWindow.xaml
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           _gameSession.CurrentPlayer.ExperiencePoints += 10;
        }
        */
    }
}
