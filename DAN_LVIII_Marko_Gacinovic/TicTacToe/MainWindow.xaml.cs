
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MarkType[] Results;

        private bool PlayerOneTurn;

        private bool GameEnded;

        public MainWindow()
        {
            InitializeComponent();

            PlayGame();
        }

        private void PlayGame()
        {
            Results = new MarkType[9];

            for (var i = 0; i < Results.Length; i++)
            {
                Results[i] = MarkType.Free;                
            }

            PlayerOneTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            });

            GameEnded = false;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GameEnded)
            {
                PlayGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (Results[index] != MarkType.Free)
            {
                return;
            }

            if (PlayerOneTurn)
            {
                Results[index] = MarkType.Cross;
            }
            else
            {
                Results[index] = MarkType.Nought;
            }

            button.Content = PlayerOneTurn ? "X" : "O";

            if (PlayerOneTurn)
            {
                PlayerOneTurn = false;
            }
            else
            {
                PlayerOneTurn = true;
            }

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            //var same = (Results[0] & Results[1] & Results[2]) == Results[0];

            // row 1 win
            if (Results[0] != MarkType.Free && (Results[0] & Results[1] & Results[2]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // row 2 win
            if (Results[3] != MarkType.Free && (Results[3] & Results[4] & Results[5]) == Results[3])
            {
                GameEnded = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // row 3 win
            if (Results[6] != MarkType.Free && (Results[6] & Results[7] & Results[8]) == Results[6])
            {
                GameEnded = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 1 win
            if (Results[0] != MarkType.Free && (Results[0] & Results[3] & Results[6]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 2 win
            if (Results[1] != MarkType.Free && (Results[1] & Results[4] & Results[7]) == Results[1])
            {
                GameEnded = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 3 win
            if (Results[2] != MarkType.Free && (Results[2] & Results[5] & Results[8]) == Results[2])
            {
                GameEnded = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // diagonal left win
            if (Results[0] != MarkType.Free && (Results[0] & Results[4] & Results[8]) == Results[0])
            {
                GameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // diagonal right win
            if (Results[2] != MarkType.Free && (Results[2] & Results[4] & Results[6]) == Results[2])
            {
                GameEnded = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.LightGreen;

                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            if (!Results.Any(result => result == MarkType.Free))
            {
                GameEnded = true;

                MessageBox.Show("No winner. \nClick anywhere to start a new game.");
            }
        }
    }
}
