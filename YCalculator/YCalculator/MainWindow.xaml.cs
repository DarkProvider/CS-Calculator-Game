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


namespace YCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


	Random rand = new Random();
		int total;
		int randomInt;

		public MainWindow()
        {
            InitializeComponent();
			checkButton.IsEnabled = false;
        }



		private void StartGame(object sender, RoutedEventArgs e)
		{
			
			randomInt = rand.Next(0, 511);
			txtQuestion.Content = "What is " + randomInt + " in Binary";
			checkButton.IsEnabled = true;
			txtAnswer.Content = "";

			foreach (var x in mainGrid.Children.OfType<TextBox>()) {

				x.Text = "0";

			}
		}

		private void ResetGame(object sender, RoutedEventArgs e)
		{
			randomInt = rand.Next(0, 511);
			txtQuestion.Content = "What is " + randomInt + " in Binary";
			checkButton.IsEnabled = true;
			txtAnswer.Content = "";

			foreach (var x in mainGrid.Children.OfType<TextBox>())
			{

				x.Text = "0";

			}
		}

		private void ShowHelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(
				"Click on the start button to begin" + Environment.NewLine + "" + Environment.NewLine +
				"Enter a 1 or a 0 into the boxes " + Environment.NewLine +
				"If you enter a 1 into a box, it will represent the value mentioned above it" + Environment.NewLine + "" + Environment.NewLine +
				"If you enter a 0 into the box, it will not count towards the total " + Environment.NewLine + "" + Environment.NewLine +
				"Once you are sure that you have chosen the right answer, click on the check button to check if your answer is correct\n" + Environment.NewLine + "" + Environment.NewLine +
				"You can always click on the reset button to reset the game and start all over again" + Environment.NewLine + "" + Environment.NewLine +
				"Don't forget to have fun!" + Environment.NewLine + "" + Environment.NewLine +
				"YazanDev", "Help for the Binary Calculator Game"
				);
		}


		private void CheckGame(object sender, RoutedEventArgs e)
		{
			total = 0;

			txtAnswer.Content = "";

			foreach (var x in mainGrid.Children.OfType<TextBox>()) {

				if (x.Text == "1") {

					total += Convert.ToInt32(x.Tag);
				}

				txtAnswer.Content += x.Text;
			}

			if (total == randomInt)
			{

				checkButton.IsEnabled = false;
				txtAnswer.Content += " is correct!";
			}
			else
			{
				txtAnswer.Content += " is incorrect!";

			}

		}
	}
}
