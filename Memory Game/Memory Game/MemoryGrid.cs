using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Memory_Game
{
    public class MemoryGrid
    {
        private Grid grid;
        int column;
        int row;

        public MemoryGrid(Grid grid, int cols, int rows)
        {

            this.grid = grid;
            InitializeGameGrid(cols, rows);
            CreateImage(cols, rows);
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "Memory";
            title.FontSize = 20;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(title, 0);
            grid.Children.Add(title);
        }
        private void CreateImage(int cols, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Console.WriteLine(column + row);
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("cb.jpg", UriKind.Relative));
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                    column = this.column;
                    row = this.row;
                }
            }
            
        }
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image AngryBird = new Image();
            AngryBird.Source = new BitmapImage(new Uri("ab1.png", UriKind.Relative));
            Grid.SetColumn(AngryBird, column);
            Grid.SetRow(AngryBird, row);
            grid.Children.Add(AngryBird);
        }
    }
}
