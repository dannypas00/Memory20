using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Grid gameGrid;
        private MemoryGrid grid;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        private string userName = "Bob";
        private int score;
        private string[,] highscores = new string[10, 2]
          { { "Bob", "20" },
            { "Ben", "18" },
            { "Jeremy", "15" },
            { "Jake", "14" },
            { "Logan", "12" },
            { "Mark", "10" },
            { "Dan", "8" },
            { "Harm", "5" },
            { "Jenny", "3" },
            { "Arthur", "1" } }; 

        public MainWindow()
        {
            //Lol, main loop is empty
        }

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }


        //Click on the play button
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenGame();
        }

        public void OpenGame()
        {
            Grid gameGrid = new Grid();
            gameGrid.Name = "GameGrid";
            Main.Children.Add(gameGrid);
            gameGrid.ShowGridLines = true;
            grid = new MemoryGrid(gameGrid, NR_OF_COLS, NR_OF_ROWS);
            //InitializeGameGrid(4, 4);
            gameGrid.Background = Brushes.Aqua;
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


        //Click on the Save File button
        private void SaveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] highscoreString = new string[10];
            //Convert from 2d to 1d array
            for (int i = 0; i < 10; i++)
            {
                highscoreString[i] = highscores[i, 0] + " - " + highscores[i, 1];
            }
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")) + "Highscores.txt";
            //G:\My Drive\HBO-ICT\Memory20\Memory Game\Highscores.txt

            File.WriteAllLines(path, highscoreString);
        }
    }
}
