
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
        #region Properties
        // array for cell values
        private MarkType[] Results;

        // property for switching the turn
        private bool PlayerOneTurn;

        // property for game end
        private bool GameEnded;
        #endregion

        #region Constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            PlayGame();
        }
        #endregion

        #region Methods
        /// <summary>
        /// method for playing the game
        /// </summary>
        private void PlayGame()
        {
            // array of cell values
            Results = new MarkType[9];

            // cleaning the board
            for (var i = 0; i < Results.Length; i++)
            {
                Results[i] = MarkType.Free;                
            }

            PlayerOneTurn = true;

            // cleaning the board colors and values
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            });

            GameEnded = false;            
        }

        /// <summary>
        /// method for button clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // starting new game
            if (GameEnded)
            {
                PlayGame();
                return;
            }

            // cast the sender to a button
            var button = (Button)sender;

            // find the button positions in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // enabling cell if it has the value
            if (Results[index] != MarkType.Free)
            {
                return;
            }

            // setting the values to the players
            if (PlayerOneTurn)
            {
                Results[index] = MarkType.Cross;
            }
            else
            {
                Results[index] = MarkType.Nought;
            }

            button.Content = PlayerOneTurn ? "X" : "O";

            // switching turns
            if (PlayerOneTurn)
            {
                PlayerOneTurn = false;
            }
            else
            {
                PlayerOneTurn = true;
            }

            // calling the method for winner check
            CheckForWinner();
        }

        /// <summary>
        /// method for winner check
        /// </summary>
        private void CheckForWinner()
        {    
            // row 1 win
            if (Results[0] != MarkType.Free && (Results[0] & Results[1] & Results[2]) == Results[0])
            {
                GameEnded = true;

                // coloring the win row
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // row 2 win
            if (Results[3] != MarkType.Free && (Results[3] & Results[4] & Results[5]) == Results[3])
            {
                GameEnded = true;

                // coloring the win row
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // row 3 win
            if (Results[6] != MarkType.Free && (Results[6] & Results[7] & Results[8]) == Results[6])
            {
                GameEnded = true;

                // coloring the win row
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 1 win
            if (Results[0] != MarkType.Free && (Results[0] & Results[3] & Results[6]) == Results[0])
            {
                GameEnded = true;

                // coloring the column win
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 2 win
            if (Results[1] != MarkType.Free && (Results[1] & Results[4] & Results[7]) == Results[1])
            {
                GameEnded = true;

                // coloring the column win
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // column 3 win
            if (Results[2] != MarkType.Free && (Results[2] & Results[5] & Results[8]) == Results[2])
            {
                GameEnded = true;

                // coloring the column win
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // diagonal left win
            if (Results[0] != MarkType.Free && (Results[0] & Results[4] & Results[8]) == Results[0])
            {
                GameEnded = true;

                // coloring the diagonal win
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // diagonal right win
            if (Results[2] != MarkType.Free && (Results[2] & Results[4] & Results[6]) == Results[2])
            {
                GameEnded = true;

                // coloring the diagonal win
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.LightGreen;

                // displaying message
                MessageBox.Show("Congratulations, we got the winner! \nClick anywhere to start a new game.");
            }

            // loop for no winner
            if (!Results.Any(result => result == MarkType.Free))
            {
                GameEnded = true;

                // displaying the message
                MessageBox.Show("No winner. \nClick anywhere to start a new game.");
            }
        }
        #endregion
    }
}
