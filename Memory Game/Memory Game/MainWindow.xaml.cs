using System.Windows;

namespace Memory_Game
{
    public partial class MainWindow : Window
    {
        private Mainmenu mainmenu;
  
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
            mainmenu = new Mainmenu(Main);
        }

    }
}