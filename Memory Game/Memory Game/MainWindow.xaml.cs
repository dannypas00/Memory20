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
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        string thema;

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }

        //Angry birds checkbox
        private void AngryBirds_Checked(object sender, RoutedEventArgs e)
        {
            thema = "ab";
        }

        //Star Wars Checkbox
        private void StarWars_Checked(object sender, RoutedEventArgs e)
        {
            thema = "sw";
        }

        //Emojis checkbox
        private void Emoji_Checked(object sender, RoutedEventArgs e)
        {
            thema = "emo";
        }

        //Click on the play button
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            player1 = PlayerName("Player 1");
            player2 = PlayerName("Player 2");
            OpenGame();
        }

        public string PlayerName(string player)
        {

            return "Test";
        }

        public void OpenGame()
        {
            if (thema != null)
            {
                Grid gameGrid = new Grid();
                gameGrid.Name = "GameGrid";
                Main.Children.Add(gameGrid);

                Label playerScores = new Label();
                playerScores.Name = "playerScores";
                playerScores.FontFamily = new FontFamily("Comic Sans MS");
                playerScores.FontSize = 30;

                string player1 = Convert.ToString(Player1Name.Text);
                string player2 = Convert.ToString(Player2Name.Text);
                grid = new MemoryGrid(gameGrid, NR_OF_COLS, NR_OF_ROWS, playerScores, player1, player2, Main, thema);
                gameGrid.Background = Brushes.Aqua;
            }
        }


        //Click on the Highscore Button
        private void HighscoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenHighscore();
        }

        //Open the highscore page
        public void OpenHighscore()
        {
            Clear();
        }
    }
}