using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SPACE_SHOOTER_GAME // Created by: Joshua C. Magoliman
{
    /// <summary>
    /// Interaction logic for Window_Game.xaml
    /// </summary>
    public partial class Window_Game : Window
    {
        #region Fields
        public static bool isUserChoosen;
        private bool isMoveLeft, isMoveRight;
        private int enemySkinNumber;
        private int intervals;
        private int playerSpeed;
        private int limit;
        private int score;
        private int healthPoints;
        private int enemySpeed;
        private string dateToday;
        private DispatcherTimer timerGameStart = new DispatcherTimer();
        private DispatcherTimer timerGameOver = new DispatcherTimer();
        private List<Rectangle> itemRemover = new List<Rectangle>();
        private Random randomNumber = new Random();
        private Rect rectangle;
        private CustomAudio inGameAudio = new CustomAudio("introduction_and_in_game.wav");
        private CustomAudio gameOverAudio = new CustomAudio("gameover.wav");
        #endregion

        #region Constructor
        public Window_Game()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            timerGameStart.Interval = TimeSpan.FromMilliseconds(20);
            timerGameStart.Tick += timerGame_Tick;
            timerGameOver.Tick += timerGameOver_Tick;
            timerGameOver.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }
        #endregion

        #region Event Handler Methods
        private void timerGame_Tick(object sender, EventArgs e)
        {
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
            rectangle = new Rect(Canvas.GetLeft(rectPlayer), Canvas.GetTop(rectPlayer), rectPlayer.Width, rectPlayer.Height);
            // Decrease the value of field called intervals by 1.
            intervals -= 1;
            lblScore.Content = "Score: " + Top10Only.AddingCommasInScore(Convert.ToString(score));
            lblHealthPoints.Content = "Health Points: " + healthPoints;
            // If the value of field called intervals is less than 1.
            if (intervals < 0)
            {
                MakeEnemies(); // Invoke this user defined methods called MakeEnemies().
                intervals = limit; // Re assign the value of field called intervals.
            }
            // Plane will go to left side.
            if (isMoveLeft == true && Canvas.GetLeft(rectPlayer) > 0)
            {
                Canvas.SetLeft(rectPlayer, Canvas.GetLeft(rectPlayer) - playerSpeed);
            }
            // Plane will go to right side.
            if (isMoveRight == true && Canvas.GetLeft(rectPlayer) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(rectPlayer, Canvas.GetLeft(rectPlayer) + playerSpeed);
            }
            // Using the foreach loop to control everything in Canvas.
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                // Check if there are rectangle that have a tag name of "bullet".
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    // Set the location in the Canvas.
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                    // Creating new object called rectBullet using the structure Rect.
                    Rect rectBullet = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    // If bullet exceeds the height.
                    if (Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x); // Add that bullet to the list called itemRemover.
                    }
                    // Using the foreach loop to control everything in Canvas.
                    foreach (var y in MyCanvas.Children.OfType<Rectangle>())
                    {
                        // Check if there is rectangle that have a tag name of "enemy".
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            // Creating new object called rectEnemy using the structure Rect.
                            Rect rectEnemy = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                            // If the object called rectBullet collided of object called rectEnemy.
                            if (rectBullet.IntersectsWith(rectEnemy))
                            {
                                itemRemover.Add(x); // Add that x variable to the list called itemRemover.
                                itemRemover.Add(y); // Add that y variable to the list called itemRemover.
                                score++; // Increment the field called score by 1.
                                CheckIfAudioMutedOrNot("scored.wav"); // Invoke this user defined method.
                            }
                        }
                    }
                }
                // Check if there is rectangle that have a tag name of "enemy".
                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    // Set the location in the Canvas.
                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed);
                    // If the enemy skip the plane.
                    if (Canvas.GetTop(x) > 750)
                    {
                        CheckIfAudioMutedOrNot("decrease_healthbar.wav"); // Invoke this user defined method.
                        itemRemover.Add(x); // Add that x variable to the list called itemRemover.
                        healthPoints -= 10;  // Decrease the field called healthPoints by 10.
                    }
                    // Creating new object called rectEnemy using the structure Rect.
                    Rect rectEnemy = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    // If the field called rectangle (it's a plane) collided of object called rectEnemy.
                    if (rectangle.IntersectsWith(rectEnemy))
                    {
                        CheckIfAudioMutedOrNot("decrease_healthbar.wav"); // Invoke this user defined method.
                        itemRemover.Add(x); // Add that x variable to the list called itemRemover.
                        healthPoints -= 5; // Decrease the field called healthPoints by 5.
                    }
                }
            }
            // Using the foreach loop to control everything in the list called itemRemover.
            foreach (var i in itemRemover)
            {
                MyCanvas.Children.Remove(i); // Remove the i variable in the Canvas.
            }
            // If the value of field called score is greater than 6.
            if (score > 5)
            {
                limit = 20; // Re assign the value of field called limit.
                enemySpeed = 15; // Re assign the value of field called enemySpeed.
            }
            // If the value of field called healthPoints is less than zero or equal to zero.
            if (healthPoints < 0 || healthPoints == 0)
            {
                GameOver(); // Invoke this user defined method called GameOver().
            }
        }
        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if (isUserChoosen == true)
            {
                this.Visibility = Visibility.Collapsed;
                timerGameOver.Stop();
                isUserChoosen = false;
            }
        }
        // The user is keep pressing.
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                isMoveLeft = true;
            }
            if (e.Key == Key.Right)
            {
                isMoveRight = true;
            }
        }
        // The user releases the touch.
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                isMoveLeft = false;
            }
            if (e.Key == Key.Right)
            {
                isMoveRight = false;
            }
            if (e.Key == Key.Space)
            {
                // Creating new object called newBullet using the structure Rect.
                Rectangle newBullet = new Rectangle
                {
                    Tag = "bullet",
                    Height = 20,
                    Width = 5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };
                // Set the location in the Canvas.
                Canvas.SetLeft(newBullet, Canvas.GetLeft(rectPlayer) + rectPlayer.Width / 2);
                Canvas.SetTop(newBullet, Canvas.GetTop(rectPlayer) - newBullet.Height);
                // Add the object called newBullet in the Canvas.
                MyCanvas.Children.Add(newBullet);
                // Invoke this user defined method.
                CheckIfAudioMutedOrNot("shooted.wav");
            }
        }
        private void OnClosing(object sender, EventArgs e)
        {
            inGameAudio.StopPlaying();
            gameOverAudio.StopPlaying();
            Application.Current.Shutdown();
        }
        #endregion

        #region User Defined Methods
        private void StartGame()
        {
            enemySkinNumber = 0;
            intervals = 100;
            playerSpeed = 10;
            limit = 50;
            score = 0;
            healthPoints = 100;
            enemySpeed = 10;
            timerGameStart.Start();
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
            MyCanvas.Focus();
            ImageBrush background = new ImageBrush();
            background.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/space_background.png"));
            MyCanvas.Background = background;
            ImageBrush playerImage = new ImageBrush();
            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/player.png"));
            rectPlayer.Fill = playerImage;
            PlayInGameAudio();
        }
        private void GameOver()
        {
            lblHealthPoints.Content = "Health Points: 0";
            lblHealthPoints.Foreground = Brushes.Red;
            timerGameStart.Stop();
            timerGameOver.Start();
            Top10Only.CheckResultInTop10Only(dateToday, Convert.ToInt32(score));
            if (Window_Introduction.isAudioOn == true)
            {
                inGameAudio.StopPlaying();
                gameOverAudio.Play(false);
            }
            Window_DialogBox nextWindow = new Window_DialogBox();
            nextWindow.ShowDialog();
        }
        private void CheckIfAudioMutedOrNot(string param_NameOfWavFile)
        {
            if (Window_Introduction.isAudioOn == true)
            {
                CustomAudio customAudio = new CustomAudio(param_NameOfWavFile);
                customAudio.Play(false);
            }
        }
        private void MakeEnemies()
        {
            ImageBrush imageBrushEnemy = new ImageBrush();
            enemySkinNumber = randomNumber.Next(1, 5);
            switch (enemySkinNumber)
            {
                case 1:
                    imageBrushEnemy.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/enemy_1.png"));
                    break;
                case 2:
                    imageBrushEnemy.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/enemy_2.png"));
                    break;
                case 3:
                    imageBrushEnemy.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/enemy_3.png"));
                    break;
                case 4:
                    imageBrushEnemy.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/enemy_4.png"));
                    break;
                case 5:
                    imageBrushEnemy.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/enemy_5.png"));
                    break;
            }
            Rectangle rectNewEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 56,
                Fill = imageBrushEnemy
            };
            Canvas.SetTop(rectNewEnemy, -100);
            Canvas.SetLeft(rectNewEnemy, randomNumber.Next(30, 430));
            MyCanvas.Children.Add(rectNewEnemy);
        }
        private void PlayInGameAudio()
        {
            if (Window_Introduction.isAudioOn == true)
            {
                inGameAudio.Play(true);
            }
        }
        #endregion
    }
}