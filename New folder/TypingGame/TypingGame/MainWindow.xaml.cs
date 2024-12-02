using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace TypingGame
{
    public partial class MainWindow : Window
    {
        private List<string> words = new List<string>
        {
            "hello", "world", "Consistency is the key to mastering new skills.",
            "typing", "game", "challenge", "WPF", "application",
            "practice harder", "stay motivated", "commit", "love",
            "The quick brown fox jumps over the lazy dog."
        };
        private string currentWord;
        private Timer gameTimer;
        private int timeLeft;
        private int score;
        private bool isPaused;

        public MainWindow()
        {
            InitializeComponent();
            TimerTextBlock.Text = "60";
            ScoreTextBlock.Text = "0";
            isPaused = false;

            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            InputTextBox.Text = "Type here...";
            InputTextBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text == "Type here...")
            {
                InputTextBox.Text = "";
                InputTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                SetPlaceholderText();
            }
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ResumeGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameTimer == null)
                return; // Ensure timer is initialized

            if (isPaused)
            {
                isPaused = false; // Resume the game
                gameTimer.Start();
                MessageBox.Show("Timer Resumed!");
            }
            else
            {
                isPaused = true; // Pause the game
                gameTimer.Stop();
                MessageBox.Show("Timer Paused!");
            }
        }

        private void StartGame()
        {
            score = 0;
            timeLeft = 60; // Set the initial game time (in seconds)
            TimerTextBlock.Text = timeLeft.ToString();
            ScoreTextBlock.Text = score.ToString();
            isPaused = false;

            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Dispose();
            }

            gameTimer = new Timer(1000);
            gameTimer.Elapsed += GameTimer_Elapsed;
            gameTimer.Start();

            LoadNextWord();
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!isPaused) // Only decrement time when the game is not paused
            {
                Dispatcher.Invoke(() =>
                {
                    if (timeLeft > 0)
                    {
                        timeLeft--;
                        TimerTextBlock.Text = timeLeft.ToString();
                    }
                    else
                    {
                        gameTimer.Stop();
                        MessageBox.Show($"Game Over! Your score: {score}");
                    }
                });
            }
        }

        private void LoadNextWord()
        {
            Random random = new Random();
            string nextWord;
            do
            {
                nextWord = words[random.Next(words.Count)];
            } while (nextWord == currentWord); // Avoid immediate repetition

            currentWord = nextWord;
            DisplayTextBox.Text = currentWord;
            InputTextBox.Clear();
        }

        private void InputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentWord))
            {
                return; // Ensure currentWord is initialized before proceeding
            }

            if (InputTextBox.Text.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
            {
                score++;
                ScoreTextBlock.Text = score.ToString();
                InputTextBox.Foreground = new SolidColorBrush(Colors.Black); // Correct text in black
                LoadNextWord();
            }
            else if (currentWord.StartsWith(InputTextBox.Text, StringComparison.OrdinalIgnoreCase))
            {
                InputTextBox.Foreground = new SolidColorBrush(Colors.Black); // Partial correct input in black
            }
            else
            {
                InputTextBox.Foreground = new SolidColorBrush(Colors.Red); // Incorrect text in red
            }
        }
    }
}
