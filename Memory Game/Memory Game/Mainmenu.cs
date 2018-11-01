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

namespace Memory_Game
{
    class Mainmenu
    {
        private StackPanel Main;
        private Highscore highscore;
        private Themakeuze themakeuze;
        string playerName1;
        string playerName2;
        TextBox player1textbox;
        TextBox player2textbox;


        public Mainmenu(StackPanel Main)
        {
            this.Main = Main;

            //"Memory Game" Label
            Label WelcomeLabel = new Label();
            WelcomeLabel.Content = "Memory Game";
            WelcomeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            WelcomeLabel.VerticalAlignment = VerticalAlignment.Top;
            WelcomeLabel.FontSize = 75;

            Main.Children.Add(WelcomeLabel);

            //"Player 1 Name" Label
            Label Player1Label = new Label();
            Player1Label.Content = "Player1 Name";
            Player1Label.HorizontalAlignment = HorizontalAlignment.Center;
            Player1Label.FontSize = 15;
            Main.Children.Add(Player1Label);

            //Player 1 enter name textbox
            TextBox player1textbox = new TextBox();
            player1textbox.Width = 250;
            player1textbox.Name = "playerName1";
            Main.Children.Add(player1textbox);
            this.player1textbox = player1textbox;

            //"Player 2 Name" Label
            Label Player2Label = new Label();
            Player2Label.Content = "Player2 Name";
            Player2Label.HorizontalAlignment = HorizontalAlignment.Center;
            Player2Label.FontSize = 15;
            Main.Children.Add(Player2Label);

            //Player 2 enter name textbox
            TextBox player2textbox = new TextBox();
            player2textbox.Width = 250;
            player2textbox.Name = "playerName2";
            Main.Children.Add(player2textbox);
            this.player2textbox = player2textbox;

            //Play Button
            Button PlayGameButton = new Button();
            PlayGameButton.Content = "Play";
            PlayGameButton.HorizontalAlignment = HorizontalAlignment.Center;
            PlayGameButton.FontSize = 25;
            PlayGameButton.Width = 250;
            PlayGameButton.Click += PlayGameButton_Click;

            Main.Children.Add(PlayGameButton);

            //Highscore Button
            Button HighscoreButton = new Button();
            HighscoreButton.Content = "Highscores";
            HighscoreButton.HorizontalAlignment = HorizontalAlignment.Center;
            HighscoreButton.FontSize = 25;
            HighscoreButton.Width = 250;
            HighscoreButton.Click += HighscoreButton_Click;

            Main.Children.Add(HighscoreButton);
        }

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }

        //Click on the Highscore Button
        private void HighscoreButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
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
        }

        //Click on the play button
        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenThemakeuze();
        }

        public void OpenThemakeuze()
        {
            playerName1 = Convert.ToString(player1textbox.Text);
            playerName2 = Convert.ToString(player2textbox.Text);
            Grid Themakeuzegrid = new Grid();
            Themakeuzegrid.Name = "Themakeuze";
            Main.Children.Add(Themakeuzegrid);
            Themakeuzegrid.ShowGridLines = true;
            themakeuze = new Themakeuze(Main, Themakeuzegrid, playerName1, playerName2);
            //InitializeGameGrid(4, 4);
            Themakeuzegrid.Background = Brushes.Aqua;
        }
    }
}
