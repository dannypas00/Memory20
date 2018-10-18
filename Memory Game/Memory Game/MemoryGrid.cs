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
        //Statics
        private Grid grid;              //Variable containing the game grid
        int cols;                       //Amount of columns
        int rows;                       //Amount of rows
                                        //List of grid coordinates
        List<string> Gridpoints = new List<string> { "00", "01", "02", "03", "10", "11", "12", "13", "20", "21", "22", "23", "30", "31", "32", "33" };
        int[] ImageKind = new int[16];  //Array for connecting images to gridpoints
        bool[] Gridmem = new bool[16];  //Array to remember made pairs

        //Temporaries
        int ImageNumbermem;             //Temporary variable containing previouos ImageNumber
        int tempImageKind = 0;          //Temporary variable containing previous ImageKind

        //Game logic
        int turn;                       //Int to check weither two turns have elapsed
        int ImageNumber;                //Connector for ImageKind to grid
        string thema = "ab";            //Settable variable containing thema                 



        //Score logic
        string playerName1;             //Name of player 1
        int playerScore1;               //Score of player 1
        string playerName2;             //Name of player 2
        int playerScore2;               //Score of player 2
        private Label playerScores;     //Variable containting the label to display player scores

        //MemoryGrid Class
        public MemoryGrid(Grid grid, int cols, int rows, Label playerScores, string playerName1, string playerName2, StackPanel Main)
        {
            //Creates the score keeper
            Main.Children.Add(playerScores);
            playerScores.Content = playerName1 + ": " + playerScore1 + "        " + playerName2 + ": " + playerScore2;

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

            //Variables from local to private
            this.playerName1 = playerName1;
            this.playerName2 = playerName2;
            this.grid = grid;
            this.playerScores = playerScores;
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;

            //Insantiate an empty grid
            InitializeGameGrid(cols, rows);
            
            //Create images in grid
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
                    //Create and set content for backgroundImage
                    Image backgroundImage = new Image();
                    backgroundImage.Name = "abbg" + Convert.ToString(row) + Convert.ToString(column);
                    backgroundImage.Source = new BitmapImage(new Uri("abbg.png", UriKind.Relative));
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);

                    //Runs trough Gridmem; Keeps pairs turned around
                    for(int i =0; i < 16; i++)
                    {
                        if (Gridmem[i] == true)
                        {
                            string gridpos = Convert.ToString(row) + Convert.ToString(column);  //Pastes together grid and row to create coordinate
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
                    //Click on backgroundImage
                    backgroundImage.MouseDown += new MouseButtonEventHandler(OnPreviewMouseLeftButtonDown);
                }
            }
        }


        //Happens on backgroundImage click
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
            string imagePos = Convert.ToString(row) + Convert.ToString(column);
            turn++;
            // Match string imagePos to List Gridpoints
            for (int i = 0; i < Gridpoints.Count; i++)
            {
                if (Gridpoints[i].Contains(imagePos))
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

            //Debug pairs

            //Console.WriteLine(Convert.ToString(Gridmem[0]));
            //Console.WriteLine(Convert.ToString(Gridmem[1]));
            //Console.WriteLine(Convert.ToString(Gridmem[2]));
            //Console.WriteLine(Convert.ToString(Gridmem[3]));
            //Console.WriteLine(Convert.ToString(Gridmem[4]));
            //Console.WriteLine(Convert.ToString(Gridmem[5]));
            //Console.WriteLine(Convert.ToString(Gridmem[6]));
            //Console.WriteLine(Convert.ToString(Gridmem[7]));
            //Console.WriteLine(Convert.ToString(Gridmem[8]));
            //Console.WriteLine(Convert.ToString(Gridmem[9]));
            //Console.WriteLine(Convert.ToString(Gridmem[10]));
            //Console.WriteLine(Convert.ToString(Gridmem[11]));
            //Console.WriteLine(Convert.ToString(Gridmem[12]));
            //Console.WriteLine(Convert.ToString(Gridmem[13]));
            //Console.WriteLine(Convert.ToString(Gridmem[14]));
            //Console.WriteLine(Convert.ToString(Gridmem[15]));

            //Goes 2 turns at a time
            if (turn > 1)
            {
                //Check if image is the same
                if (ImageKind[ImageNumber] + 1 == tempImageKind )
                {
                    Console.WriteLine("PAIR!");
                }
                else
                {
                    //Resets field minus pairs
                    Gridmem[ImageNumber] = false;
                    Gridmem[ImageNumbermem] = false;
                    grid.Children.Clear();
                    CreateImage(cols, rows);
                }
                turn = 0;
            }
            //Sets temps to remember
            ImageNumbermem = ImageNumber;
            tempImageKind = ImageKind[ImageNumber] + 1;
            //Show player scores
            playerScores.Content = playerName1 + ": " + playerScore1 + "        " + playerName2 + ": " + playerScore2;
        }
    }
}
