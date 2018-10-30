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
        private Mainmenu mainmenu;

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;

  
        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }
        
        private void Start_Game(object sender, RoutedEventArgs e)
        {
            OpenMainMenu();
        }

        public void OpenMainMenu()
        {
            Clear();
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