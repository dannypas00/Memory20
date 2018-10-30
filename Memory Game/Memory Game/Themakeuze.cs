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
    class Themakeuze
    {
        public string player1;
        public string player2;
        private Mainmenu mainmenu;
        private StackPanel Main;
        private MemoryGrid grid;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

        public Themakeuze(StackPanel Main, Grid Themakeuzegrid)

        {
            this.Main = Main;

            Label myLabel = new Label();
            myLabel.Content = "KIES EEN THEMA";
            myLabel.HorizontalAlignment = HorizontalAlignment.Center;
            myLabel.VerticalAlignment = VerticalAlignment.Top;
            myLabel.FontSize = 75;
 

            Main.Children.Add(myLabel);

            Button AngryBirdsTheme = new Button();
            AngryBirdsTheme.Content = "Angry Birds";
            AngryBirdsTheme.HorizontalAlignment = HorizontalAlignment.Center;
            AngryBirdsTheme.FontSize = 25;
            AngryBirdsTheme.Width = 250;
            AngryBirdsTheme.Click += PlayAngryBirdsTheme_Click;

            Main.Children.Add(AngryBirdsTheme);

            Button StarWarsTheme = new Button();
            StarWarsTheme.Content = "Star Wars";
            StarWarsTheme.HorizontalAlignment = HorizontalAlignment.Center;
            StarWarsTheme.FontSize = 25;
            StarWarsTheme.Width = 250;
            StarWarsTheme.Click += PlayStarWarsTheme_Click;

            Main.Children.Add(StarWarsTheme);

            Button EmojiTheme = new Button();
            EmojiTheme.Content = "Emoji's";
            EmojiTheme.HorizontalAlignment = HorizontalAlignment.Center;
            EmojiTheme.FontSize = 25;
            EmojiTheme.Width = 250;
            EmojiTheme.Click += PlayEmojiTheme_Click;

            Main.Children.Add(EmojiTheme);

            Button MainMenuButton = new Button();
            MainMenuButton.Content = "Main Menu";
            MainMenuButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainMenuButton.FontSize = 25;
            MainMenuButton.Click += MainMenuButton_Click;

            Main.Children.Add(MainMenuButton);

        }

   
        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }

        //Click on the MainMenu Button
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            OpenMainMenu(Main);
        }

        private void OpenMainMenu(StackPanel Main)
        {
            Grid MainMenugrid = new Grid();
            MainMenugrid.Name = "MainMenu";
            Main.Children.Add(MainMenugrid);
            MainMenugrid.ShowGridLines = true;
            mainmenu = new Mainmenu(Main, MainMenugrid);
            //InitializeGameGrid(4, 4);
            MainMenugrid.Background = Brushes.Aqua;
        }

        //Click on the Angry Birds Button
        private void PlayAngryBirdsTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            //player1 = PlayerName("Player 1");
            //player2 = PlayerName("Player 2");
            OpenGame(Main);
        }
        //Click on the Star Wars Button
        private void PlayStarWarsTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            //player1 = PlayerName("Player 1");
            //player2 = PlayerName("Player 2");
            OpenGame(Main);
        }
        //Click on the Emoji Button
        private void PlayEmojiTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            //player1 = PlayerName("Player 1");
            //player2 = PlayerName("Player 2");
            OpenGame(Main);
        }
        public void OpenGame(StackPanel Main)
        {
            Grid gameGrid = new Grid();
            gameGrid.Name = "GameGrid";
            Main.Children.Add(gameGrid);

            Label playerScores = new Label();
            playerScores.Name = "playerScores";
            playerScores.FontFamily = new FontFamily("Comic Sans MS");
            playerScores.FontSize = 30;

            //string player1 = Convert.ToString(Player1Name.Text);
            //string player2 = Convert.ToString(Player2Name.Text);
            grid = new MemoryGrid(gameGrid, NR_OF_COLS, NR_OF_ROWS, playerScores, player1, player2, Main);
            gameGrid.Background = Brushes.Aqua;
        }
    }
}
