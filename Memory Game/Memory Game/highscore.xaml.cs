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

namespace Memory_Game.Properties
{
    /// <summary>
    /// Interaction logic for highscore.xaml
    /// </summary>
    public partial class highscore : Window
    {
        public highscore()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            Highscore.Children.Clear();
        }

        //Click on the back button
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            OpenMain();
        }
        
        //Open Main menu page
        public void OpenMain()
        {
            Clear();
        }
    }
}
