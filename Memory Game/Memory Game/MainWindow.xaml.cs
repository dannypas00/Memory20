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
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;

        public MainWindow()
        {
            InitializeComponent();
            //OpenGame();
        }
        
        //Clearing screen
        public void Clear()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
        }
        
        private void OpenGame()
        {
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS);
        }

        private void ClearGrid(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void CreateGrid(object sender, RoutedEventArgs e)
        {
            OpenGame();
        }
    }
}
