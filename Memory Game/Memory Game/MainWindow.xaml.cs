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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemoryGrid grid;
        StackPanel panel;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

        public MainWindow()
        {
            panel = Main;
            InitializeComponent();
            //OpenGame();
        }
        
        //Clearing screen
        /*public void Clear()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
        }*/

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
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS);
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
