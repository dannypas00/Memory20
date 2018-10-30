using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Memory_Game
{
    class home
    {
        public string player1;
        public string player2;
        private Highscore highscore;
        private Themakeuze themakeuze;
        private StackPanel Main;

        public home(StackPanel Main)
        {
            this.Main = Main;

            Label WelcomeLabel = new Label();
            WelcomeLabel.Content = "Memory Game";
            WelcomeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            WelcomeLabel.VerticalAlignment = VerticalAlignment.Top;
            WelcomeLabel.FontSize = 75;

            //Main.Children.Add(WelcomeLabel);


            Label Player1Label = new Label();
            Player1Label.Content = "Player1";
            Player1Label.HorizontalAlignment = HorizontalAlignment.Center;
            Player1Label.FontSize = 15;
            Main.Children.Add(Player1Label);


            TextBox player1textbox = new TextBox();
            player1textbox.Width = 250;
            Main.Children.Add(player1textbox);

            Label Player2Label = new Label();
            Player2Label.Content = "Player2";
            Player2Label.HorizontalAlignment = HorizontalAlignment.Center;
            Player2Label.FontSize = 15;
            Main.Children.Add(Player2Label);


            TextBox player2textbox = new TextBox();
            player2textbox.Width = 250;
            Main.Children.Add(player2textbox);


            player1 = PlayerName("Player 1");
            player2 = PlayerName("Player 2");

            Button PlayGameButton = new Button();
            PlayGameButton.Content = "Play";
            PlayGameButton.HorizontalAlignment = HorizontalAlignment.Center;
            PlayGameButton.FontSize = 25;
            PlayGameButton.Width = 250;
            PlayGameButton.Click += PlayGameButton_Click;

            Main.Children.Add(PlayGameButton);

            Button HighscoreButton = new Button();
            HighscoreButton.Content = "Highscores";
            HighscoreButton.HorizontalAlignment = HorizontalAlignment.Center;
            HighscoreButton.FontSize = 25;
            HighscoreButton.Width = 250;
            HighscoreButton.Click += HighscoreButton_Click;

            Main.Children.Add(HighscoreButton);

        }

        public string PlayerName(string player)
        {

            return "Test";
        }

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }

        //Click on the Highscore Button
        private void HighscoreButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            OpenHighscore(Main);
        }

        //Open the highscore page
        public void OpenHighscore(StackPanel Main)
        {
            Label myLabel = new Label();
            myLabel.Content = "HIGHSCORES";
            myLabel.HorizontalAlignment = HorizontalAlignment.Center;
            myLabel.VerticalAlignment = VerticalAlignment.Top;
            myLabel.FontSize = 75;
            Main.Children.Add(myLabel);

            Grid Highscoregrid = new Grid();
            Highscoregrid.Name = "Highscore";
            Main.Children.Add(Highscoregrid);
            Highscoregrid.ShowGridLines = true;
            highscore = new Highscore(Main, Highscoregrid);
            //InitializeGameGrid(4, 4);
            //Highscoregrid.Background = Brushes.Aqua;
        }
        //Click on the play button
        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenThemakeuze();
        }

        public void OpenThemakeuze()
        {
            Grid Themakeuzegrid = new Grid();
            Themakeuzegrid.Name = "Themakeuze";
            Main.Children.Add(Themakeuzegrid);
            Themakeuzegrid.ShowGridLines = true;
            themakeuze = new Themakeuze(Main, Themakeuzegrid);
            //InitializeGameGrid(4, 4);
            Themakeuzegrid.Background = Brushes.Aqua;
        }
    }

    internal class Themakeuze
    {
        private StackPanel main;
        private Grid themakeuzegrid;

        public Themakeuze(StackPanel main, Grid themakeuzegrid)
        {
            this.main = main;
            this.themakeuzegrid = themakeuzegrid;
        }
    }

    internal class Highscore
    {
        private StackPanel main;
        private Grid highscoregrid;

        public Highscore(StackPanel main, Grid highscoregrid)
        {
            this.main = main;
            this.highscoregrid = highscoregrid;
        }
    }
}
