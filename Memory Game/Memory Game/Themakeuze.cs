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
        string thema;
        private Mainmenu mainmenu;
        private StackPanel Main;
        private string playerName1;
        private string playerName2;
        private MemoryGrid grid;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

        public Themakeuze(StackPanel Main, Grid Themakeuzegrid, string playerName1, string playerName2)

        {
            this.Main = Main;
            this.playerName1 = playerName1;
            this.playerName2 = playerName2;
            
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
            MainMenugrid.Background = Brushes.Aqua;
        }

        //Click on the Angry Birds Button
        private void PlayAngryBirdsTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            thema = "ab";
            OpenGame(Main);
        }
        //Click on the Star Wars Button
        private void PlayStarWarsTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            thema = "sw";
            OpenGame(Main);
        }
        //Click on the Emoji Button
        private void PlayEmojiTheme_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            thema = "emo";
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
            grid = new MemoryGrid(gameGrid, NR_OF_COLS, NR_OF_ROWS, playerScores, playerName1, playerName2, Main, thema);
            gameGrid.Background = Brushes.Aqua;
        }
    }
}
