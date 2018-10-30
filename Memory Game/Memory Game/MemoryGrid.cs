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
using System.Windows.Threading;

namespace Memory_Game
{
    public class MemoryGrid
    {
        //Timer that ticks every 0.3 seconds
        DispatcherTimer timer = new DispatcherTimer();
        //Timer that starts ticking if you don't get a pair and after one second flips the card back over
        DispatcherTimer timer2 = new DispatcherTimer();
        bool timed = true;              //Boolean to check if the flip timer has finished

        //Statics
        private Grid grid;              //Variable containing the game grid
        int cols;                       //Amount of columns
        int rows;                       //Amount of rows
                                        //List of grid coordinates
        List<string> Gridpoints = new List<string> { "00", "01", "02", "03", "10", "11", "12", "13", "20", "21", "22", "23", "30", "31", "32", "33" };
        int[] ImageKind = new int[16];  //Array for connecting images to gridpoints
        bool[] Gridmem = new bool[16];  //Array to remember made pairs
        int player = 1;

        //Temporaries
        int ImageNumbermem;             //Temporary variable containing previouos ImageNumber
        int tempImageKind;              //Temporary variable containing previous ImageKind

        //Game logic
        int turn = 0;                       //Int to check weither two turns have elapsed
        int ImageNumber;                //Connector for ImageKind to grid
        string thema = "ab";            //Settable variable containing thema             
              

        //Score logic
        string playerName1;             //Name of player 1
        int playerScore1;               //Score of player 1
        string playerName2;             //Name of player 2
        int playerScore2;               //Score of player 2
        private Label playerScores;     //Variable containting the label to display player scores
        private StackPanel Main;
        private Mainmenu mainmenu;

        //Saving and loading
        //Path for the save file
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")) + "Save.sav";


        //MemoryGrid Class
        public MemoryGrid(Grid grid, int cols, int rows, Label playerScores, string playerName1, string playerName2, StackPanel Main, string thema)
        {
            //Variables from local to private
            this.playerName1 = playerName1;
            this.playerName2 = playerName2;
            this.grid = grid;
            this.playerScores = playerScores;
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.thema = thema;
            this.Main = Main;

            //loadSave();
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

            //Insantiate an empty grid
            InitializeGameGrid(cols, rows);

            //Starts the timers
            DispatcherTimerSample();

            //Create images in grid
            CreateImage(cols, rows);

            Button MainMenuButton = new Button();
            MainMenuButton.Content = "Main Menu";
            MainMenuButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainMenuButton.FontSize = 25;
            MainMenuButton.Click += MainMenuButton_Click;
            MainMenuButton.Width = 800;

            Main.Children.Add(MainMenuButton);
        }

        //Save Game
        private void save()
        {
            System.IO.File.WriteAllText(path, "");
            string[] save = new string[22];
            save[0] = "playerName1" + playerName1;
            save[1] = "playerName2" + playerName2;
            save[2] = "playerScore1" + playerScore1;
            save[3] = "playerScore2" + playerScore2;
            save[4] = "turn" + turn;
            int j = 0;
            foreach (bool i in Gridmem)
            {
                save[5 + j] = "Gridmem" + i;
                j++;
            }
            save[21] = "thema" + thema;
            System.IO.File.WriteAllLines(path, save);
        }

        /*
        //Load Game
        private void loadSave()
        {
            string[] Read = System.IO.File.ReadAllLines(path);
            foreach (string line in Read)
            {
                Console.WriteLine(line);
            }
            int runs = 0;
            foreach (string line in Read)
            {
                if (line.Contains("playerName1")) { playerName1 = line.Substring("playerName1".Length); }
                if (line.Contains("playerName2")) { playerName2 = line.Substring("playerName2".Length); }
                if (line.Contains("playerScore1")) { playerScore1 = Convert.ToInt32(line.Substring("playerScore1".Length)); }
                if (line.Contains("playerScore2")) { playerScore2 = Convert.ToInt32(line.Substring("playerScore2".Length)); }
                if (line.Contains("turn")) { turn = Convert.ToInt32(line.Substring("turn".Length)); }
                if (line.Contains("Gridmem"))
                {
                    switch (line.Substring("Gridmem".Length))
                    {
                        case "true":
                            Gridmem[runs] = true;
                            break;
                        case "false":
                            Gridmem[runs] = false;
                            break;
                        default:
                            break;
                    }
                    runs++;
                }
                if (line.Contains("thema")) { thema = line.Substring("thema".Length); }
                grid.Children.Clear();
                CreateImage(cols, rows);
            }
        }*/




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
                    backgroundImage.Name = thema + "bg" + Convert.ToString(row) + Convert.ToString(column);
                    backgroundImage.Source = new BitmapImage(new Uri(thema + "bg.png", UriKind.Relative));
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);

                    //Runs trough Gridmem; Keeps pairs turned around
                    for (int i = 0; i < 16; i++)
                    {
                        if (Gridmem[i] == true)
                        {
                            string gridpos = Convert.ToString(row) + Convert.ToString(column);  //Pastes together grid and row to create coordinate
                            if (Gridpoints[i].Contains(gridpos))
                            {
                                ImageNumber = i;
                                Image AngryBird = new Image();
                                AngryBird.Source = new BitmapImage(new Uri(thema + (ImageKind[ImageNumber] + 1) + ".png", UriKind.Relative));
                                AngryBird.Name = thema + Convert.ToString(ImageKind[ImageNumber]);
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
            if (timed == true)
            {
                save();
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
                AngryBird.Name = thema + Convert.ToString(ImageKind[ImageNumber]);
                Grid.SetColumn(AngryBird, column);
                Grid.SetRow(AngryBird, row);
                grid.Children.Add(AngryBird);

                Gridmem[ImageNumber] = true;

                turn++;
                if (turn != 2)
                {
                    ImageNumbermem = ImageNumber;
                    tempImageKind = ImageKind[ImageNumber];
                }
            }
        }


        private void Turn()
        {
            //Goes 2 turns at a time
            if (turn > 1)
            {
                player++;
                //Check if image is the same
                if (ImageKind[ImageNumber] == tempImageKind || ImageKind[ImageNumber] == tempImageKind)
                {
                    Console.WriteLine("PAIR!");
                    //Checks which player's turn it is
                    if (player % 2 == 0)
                    {
                        playerScore2 += 10;
                    }
                    else
                    {
                        playerScore1 += 10;
                    }
                    player -= 1;
                }
                else
                {
                    timed = false;
                    timer2.Start();
                }
                turn = 0;
            }
        }


        private void Clear()
        {
            Gridmem[ImageNumber] = false;
            Gridmem[ImageNumbermem] = false;
            grid.Children.Clear();
            CreateImage(cols, rows);
        }


        public void DispatcherTimerSample()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer2.Tick += timer2_Tick;
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            Turn();
            playerScores.Content = playerName1 + ": " + playerScore1 + "        " + playerName2 + ": " + playerScore2;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Clear();
            timer2.Stop();
            timed = true;
        }




        //Clear the screen
        public void ClearScreen()
        {
            Main.Children.Clear();
        }



        //Click on the MainMenu Button
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            OpenMainMenu(Main);
        }

        private void OpenMainMenu(StackPanel Main)
        {
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
