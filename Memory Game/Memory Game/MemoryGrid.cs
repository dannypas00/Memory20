using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Memory_Game
{
    public class MemoryGrid
    {
        private Grid grid;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);
            AddLabel();
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
            CreateImage();
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
        private Image CreateImage()
        {
            var img = CreateImage();
            Grid.SetRow(img, 0);
            Grid.SetColumn(img, 0);
            grid_Main.Children.Add(img);
            Image Mole = new Image();
            Mole.Width = 25;
            Mole.Height = 25;
            ImageSource MoleImage = new cb.jpg(new Uri(CheckBox.jpg));
            Mole.Source = MoleImage;
            return Mole;
        }
    }
}
