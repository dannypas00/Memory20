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
    public partial class MainWindow : Window
    {
        public string player1;
        public string player2;
        //private Grid gameGrid;
        private MemoryGrid grid;
        private Highscore highscore;
        private Themakeuze themakeuze;
        private Mainmenu mainmenu;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }


        //Click on the play button
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
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

        ////Click on the Angry Birds Button
        //private void PlayGameButton(object sender, RoutedEventArgs e)
        //{
        //    Clear();
        //    player1 = PlayerName("Player 1");
        //    player2 = PlayerName("Player 2");
        //    OpenGame();
        //}

        //public string PlayerName(string player)
        //{

        //    return "Test";
        //}

        //public void OpenGame()
        //{
        //    Grid gameGrid = new Grid();
        //    gameGrid.Name = "GameGrid";
        //    Main.Children.Add(gameGrid);

        //    Label playerScores = new Label();
        //    playerScores.Name = "playerScores";
        //    playerScores.FontFamily = new FontFamily("Comic Sans MS");
        //    playerScores.FontSize = 30;

        //    string player1 = Convert.ToString(Player1Name.Text);
        //    string player2 = Convert.ToString(Player2Name.Text);
        //    grid = new MemoryGrid(gameGrid, NR_OF_COLS, NR_OF_ROWS, playerScores, player1, player2, Main);
        //    gameGrid.Background = Brushes.Aqua;
        //}


        //Click on the Highscore Button
        private void HighscoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenHighscore();
        }

        //Open the highscore page
        public void OpenHighscore()
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

        //Click on the MainMenu Button
        private void MainMenuButton(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenMainMenu();
        }

        private void OpenMainMenu()
        {
            Grid MainMenugrid = new Grid();
            MainMenugrid.Name = "MainMenu";
            Main.Children.Add(MainMenugrid);
            MainMenugrid.ShowGridLines = true;
            mainmenu = new Mainmenu(Main, MainMenugrid);
            //InitializeGameGrid(4, 4);
            MainMenugrid.Background = Brushes.Aqua;
        }
    }
}