﻿using System;
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
        int turn, Temprow, Tempcolumn = 0;
        int ImageNumber,ImageNumbermem, cols, rows;
        int Tempmem = 0;
        string thema = "ab";
        string name;

        //Make empty array For the Images
        int[] ImageKind = new int[16];
        bool[] Gridmem = new bool[16];
        //List to match grindpoints to a specific spot in the code
        List<string> Gridpoints = new List<string>
        {
            "00","01","02","03","10","11","12","13","20","21","22","23","30","31","32","33"
        };

        private Grid grid;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            //Make a list of double images in the array
            for (int i = 0; i < 8; i++)
            {
                ImageKind[i] = i;
                ImageKind[i + 8] = i;
                Gridmem[i] = false;
            }

            //Randomize these images in the array
            Random rnd = new Random();
            ImageKind = ImageKind.OrderBy(x => rnd.Next()).ToArray();

            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            //Write an empty grid
            InitializeGameGrid(cols, rows);
            
            //Write images into the grids
            CreateImage(cols, rows);

        }

        //Create Empty grid cols x rows
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

        //Create background images in the grids
        private void CreateImage(int cols, int rows)
        {

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {

                    Image backgroundImage = new Image();
                    backgroundImage.Name = "cb" + Convert.ToString(row) + Convert.ToString(column);
                    backgroundImage.Source = new BitmapImage(new Uri("abbg.png", UriKind.Relative));

                    // Add on click function
                    backgroundImage.MouseDown += new MouseButtonEventHandler(OnPreviewMouseLeftButtonDown);

                    // Write Background images on the grid
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                    for(int i =0; i < 16; i++)
                    {
                        if (Gridmem[i] == true)
                        {
                            string gridpos = Convert.ToString(row) + Convert.ToString(column);
                            if (Gridpoints[i].Contains(gridpos))
                            {
                                ImageNumber = i;
                                Image AngryBird = new Image();
                                AngryBird.Source = new BitmapImage(new Uri(thema + (ImageKind[ImageNumber] + 1) + ".png", UriKind.Relative));
                                AngryBird.Name = "ab" + Convert.ToString(ImageKind[ImageNumber]);
                                Grid.SetColumn(AngryBird, column);
                                Grid.SetRow(AngryBird, row);
                                grid.Children.Add(AngryBird);
                            }
                            
                        }
                    
                    }

                }
            }

        }

        private void OnPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            var point = Mouse.GetPosition(grid);
            int row = 0;
            int column = 0;

            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;


            // calc row mouse was over
            foreach (var rowDefinition in grid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                column++;
            }



            Image AngryBird = new Image();

            // Make the grid point into a string so you can reconize it in the list (Gridpoints)
            string abc = Convert.ToString(row) + Convert.ToString(column);
            turn++;



            // Match string abc to List (Gridpoints
            for (int i = 0; i < Gridpoints.Count; i++)
            {
                if (Gridpoints[i].Contains(abc))
                {
                    ImageNumber = i;
                }
            }

            // Write the Randomized image on the spot you click
            AngryBird.Source = new BitmapImage(new Uri(thema + (ImageKind[ImageNumber] + 1) + ".png", UriKind.Relative));
            AngryBird.Name = "ab" + Convert.ToString(ImageKind[ImageNumber]);
            Grid.SetColumn(AngryBird, column);
            Grid.SetRow(AngryBird, row);
            grid.Children.Add(AngryBird);
            Console.WriteLine(AngryBird.Name);
            Gridmem[ImageNumber] = true;
            Console.WriteLine(Convert.ToString(ImageKind[ImageNumber]));
            Console.WriteLine(Convert.ToString(Gridmem[0]));
            Console.WriteLine(Convert.ToString(Gridmem[1]));
            Console.WriteLine(Convert.ToString(Gridmem[2]));
            Console.WriteLine(Convert.ToString(Gridmem[3]));
            Console.WriteLine(Convert.ToString(Gridmem[4]));
            Console.WriteLine(Convert.ToString(Gridmem[5]));
            Console.WriteLine(Convert.ToString(Gridmem[6]));
            Console.WriteLine(Convert.ToString(Gridmem[7]));
            Console.WriteLine(Convert.ToString(Gridmem[8]));
            Console.WriteLine(Convert.ToString(Gridmem[9]));
            Console.WriteLine(Convert.ToString(Gridmem[10]));
            Console.WriteLine(Convert.ToString(Gridmem[11]));
            Console.WriteLine(Convert.ToString(Gridmem[12]));
            Console.WriteLine(Convert.ToString(Gridmem[13]));
            Console.WriteLine(Convert.ToString(Gridmem[14]));
            Console.WriteLine(Convert.ToString(Gridmem[15]));


            if (turn > 1)
            {
                if (ImageKind[ImageNumber] + 1 == Tempmem )
                {
                    //keep turned
                    Console.WriteLine("PAIR!");
                }
                else
                {
                    Gridmem[ImageNumber] = false;
                    Gridmem[ImageNumbermem] = false;
                    grid.Children.Clear();
                    CreateImage(cols, rows);
                }
                turn = 0;

            }
            ImageNumbermem = ImageNumber;
            Tempmem = ImageKind[ImageNumber] + 1;
            Temprow = row;
            Tempcolumn = column;
            name = AngryBird.Name;











        }

    }
}
