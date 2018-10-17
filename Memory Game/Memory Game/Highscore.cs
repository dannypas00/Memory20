using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Memory_Game
{
    public class Highscore
    {
        public Highscore(StackPanel Main)
        {
            Label myLabel = new Label();
            myLabel.Content = "Hello, world!";
            Main.Children.Add(myLabel);
        }
    }
}
