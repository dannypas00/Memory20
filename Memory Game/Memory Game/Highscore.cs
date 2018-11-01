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

namespace Memory_Game
{
    public class Highscore
    {
        private Mainmenu mainmenu;
        StackPanel Main;
        public Grid Highscoregrid;
        int cols = 0;
        int rows;
        int[] score = new int[10] { 8861, 8987, 9967, 9720, 7116, 7051, 6822, 8834, 5461, 8683 };
        int s = 0;

        public Highscore(StackPanel Main, Grid Highscoregrid)
        {
            Array.Sort(score);
            Array.Reverse(score);

            this.Main = Main;
            this.Highscoregrid = Highscoregrid;

            for (int row = 0; row < 12; row++)
            {
                Highscoregrid.RowDefinitions.Add(new RowDefinition());
                Highscoregrid.RowDefinitions[rows].MinHeight = 50;
            }

            for (int columns = 0; columns < 3; columns++)
            {
                Highscoregrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (rows = 0; rows < 1; rows++)
            {
                //Label for "Place" title
                Label placetextLabel = new Label();
                placetextLabel.Content = ("PLACE");
                placetextLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                placetextLabel.FontSize = 25;
                Grid.SetColumn(placetextLabel, 0);
                Grid.SetRow(placetextLabel, 0);
                Highscoregrid.Children.Add(placetextLabel);
                placetextLabel.FontWeight = FontWeights.Bold;

                //Label for "Score" title
                Label scoretextLabel = new Label();
                scoretextLabel.Content = ("SCORE");
                scoretextLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                scoretextLabel.FontSize = 25;
                scoretextLabel.FontWeight = FontWeights.Bold;
                Grid.SetColumn(scoretextLabel, 1);
                Grid.SetRow(scoretextLabel, 0);
                Highscoregrid.Children.Add(scoretextLabel);

                //Label for "Name" title
                Label nametextLabel = new Label();
                nametextLabel.Content = ("NAME");
                nametextLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                nametextLabel.FontSize = 25;
                nametextLabel.FontWeight = FontWeights.Bold;
                Grid.SetColumn(nametextLabel, 2);
                Grid.SetRow(nametextLabel, 0);
                Highscoregrid.Children.Add(nametextLabel);
            }

            //Create Scoreboard
            for (rows = 1; rows < 11; rows++)
            {
                {
                    Label placenumberLabel = new Label();
                    placenumberLabel.Content = ("NO" + (rows));
                    placenumberLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    placenumberLabel.FontSize = 25;

                    // Write highscore on the grid
                    Grid.SetColumn(placenumberLabel, 0);
                    Grid.SetRow(placenumberLabel, rows);
                    Highscoregrid.Children.Add(placenumberLabel);
                }

                {
                    Label scoreLabel = new Label();
                    scoreLabel.Content = (Convert.ToString(score[s++]));
                    scoreLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    scoreLabel.FontSize = 25;

                    // Write highscore on the grid
                    Grid.SetColumn(scoreLabel, 1);
                    Grid.SetRow(scoreLabel, rows);
                    Highscoregrid.Children.Add(scoreLabel);
                }
            }

            //Main Menu Button
            Button MainMenuButton = new Button();
            MainMenuButton.Content = "Main Menu";
            MainMenuButton.HorizontalAlignment = HorizontalAlignment.Center;
            MainMenuButton.FontSize = 25;
            MainMenuButton.Click += MainMenuButton_Click;

            Main.Children.Add(MainMenuButton);
        }

        //Clear the screen
        public void Clear()
        {
            Main.Children.Clear();
        }

        //Click on the MainMenu Button
        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMainMenu();
        }

        //Function called on main menu button click
        private void OpenMainMenu()
        {
            Clear();
            mainmenu = new Mainmenu(Main);
        }
    }
}