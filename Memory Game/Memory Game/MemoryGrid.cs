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
        int ImageNumber;
        BitmapImage[] ImageKind = new BitmapImage[16];
        

        //BitmapImage[] RandomImageKind = new BitmapImage[16];
        List<string> Gridpoints = new List<string>
        {
            "00","01","02","03","10","11","12","13","20","21","22","23","30","31","32","33"
        };
        //string[] GridPoints = new string[16] {
        //     "00",
        //     "01",
        //     "02",
        //     "03",
        //     "10",
        //     "11",
        //     "12",
        //     "13",
        //     "20",
        //     "21",
        //     "23",
        //     "24",
        //     "30",
        //     "31",
        //     "32",
        //     "33"
        //};
        private Grid grid;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            for (int i = 0; i < 8; i++)
            {
                ImageKind[i] = new BitmapImage(new Uri("ab" + (i + 1) + ".png", UriKind.Relative));
                ImageKind[i + 8] = new BitmapImage(new Uri("ab" + (i + 1) + ".png", UriKind.Relative));
            }
            Random rnd = new Random();
            ImageKind = ImageKind.OrderBy(x => rnd.Next()).ToArray();


            //Random rnd = new Random();
            //BitmapImage[] RandomImageKind = ImageKind.OrderBy(x => rnd.Next()).ToArray();

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

                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("cb.jpg", UriKind.Relative));
                    backgroundImage.MouseDown += new MouseButtonEventHandler(OnPreviewMouseLeftButtonDown);
                    //backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick(row, column));
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                    

                }
            }

        }
        //private void CardClick(object sender, MouseButtonEventArgs e, int row, int column)
        //{
        //    Image AngryBird = new Image();
        //    AngryBird.Source = new BitmapImage(new Uri("ab1.png", UriKind.Relative));
        //    Grid.SetColumn(AngryBird, column);
        //    Grid.SetRow(AngryBird, row);
        //    grid.Children.Add(AngryBird);
        //}

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

                string abc = Convert.ToString(row) + Convert.ToString(column);
                Console.WriteLine(abc);

                for (int i=0;i < Gridpoints.Count; i++)
                {
                if(Gridpoints[i].Contains(abc))
                {
                    ImageNumber = i;
                    Console.WriteLine("i is: " + i);
                    Console.WriteLine("ImageNumber is: " + ImageNumber);
                }
                }
                

                AngryBird.Source = ImageKind[ImageNumber];
                Grid.SetColumn(AngryBird, column);
                Grid.SetRow(AngryBird, row);
                grid.Children.Add(AngryBird);
                //ImageNumber++;
                

                
            


        }

    }
}
