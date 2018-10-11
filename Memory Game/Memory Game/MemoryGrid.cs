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
        }

        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "Memory Game";
            title.FontSize = 20;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 0);
            grid.Children.Add(title);
        }
    }
}
