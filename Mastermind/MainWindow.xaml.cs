using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Mastermind
{
    public partial class MainWindow : Window
    {
        //Variabelen worden globaal geinitieerd
        string color1, color2, color3, color4;
        int attempts = 0;
        int score = 100;
        int row = 0;
        List<Label> colorLabels = new List<Label>();

        public MainWindow()
        {
            InitializeComponent();
            GameStart();
        }
        
        private void GameStart()
        {
            CodeRandomizer(out color1, out color2, out color3, out color4);
            correctCodeTextBox.Text = $"{color1}, {color2}, {color3}, {color4}";
            score = 100;
            attempts = 0;
            row = 0;


            RemoveAttemptLabels();
            ResetChoiceLabels();

            Mastermind.Title = $"Pogingen: 0";
            scoreTextBox.Text = "100";
        }

        private void ComboBox_Selection(object sender, SelectionChangedEventArgs e)
        {
            if (sender == firstComboBox)
            {
                switch (firstComboBox.SelectedIndex)
                {
                    case 0:
                        firstColorLabel.Background = Brushes.White;
                        break;
                    case 1:
                        firstColorLabel.Background = Brushes.Red;
                        break;
                    case 2:
                        firstColorLabel.Background = Brushes.Orange;
                        break;
                    case 3:
                        firstColorLabel.Background = Brushes.Yellow;
                        break;
                    case 4:
                        firstColorLabel.Background = Brushes.Green;
                        break;
                    case 5:
                        firstColorLabel.Background = Brushes.Blue;
                        break;
                }
            }
            else if (sender == secondComboBox)
            {
                switch (secondComboBox.SelectedIndex)
                {
                    case 0:
                        secondColorLabel.Background = Brushes.White;
                        break;
                    case 1:
                        secondColorLabel.Background = Brushes.Red;
                        break;
                    case 2:
                        secondColorLabel.Background = Brushes.Orange;
                        break;
                    case 3:
                        secondColorLabel.Background = Brushes.Yellow;
                        break;
                    case 4:
                        secondColorLabel.Background = Brushes.Green;
                        break;
                    case 5:
                        secondColorLabel.Background = Brushes.Blue;
                        break;
                }
            }
            else if (sender == thirdComboBox)
            {
                switch (thirdComboBox.SelectedIndex)
                {
                    case 0:
                        thirdColorLabel.Background = Brushes.White;
                        break;
                    case 1:
                        thirdColorLabel.Background = Brushes.Red;
                        break;
                    case 2:
                        thirdColorLabel.Background = Brushes.Orange;
                        break;
                    case 3:
                        thirdColorLabel.Background = Brushes.Yellow;
                        break;
                    case 4:
                        thirdColorLabel.Background = Brushes.Green;
                        break;
                    case 5:
                        thirdColorLabel.Background = Brushes.Blue;
                        break;
                }
            }
            else if (sender == fourthComboBox)
            {
                switch (fourthComboBox.SelectedIndex)
                {
                    case 0:
                        fourthColorLabel.Background = Brushes.White;
                        break;
                    case 1:
                        fourthColorLabel.Background = Brushes.Red;
                        break;
                    case 2:
                        fourthColorLabel.Background = Brushes.Orange;
                        break;
                    case 3:
                        fourthColorLabel.Background = Brushes.Yellow;
                        break;
                    case 4:
                        fourthColorLabel.Background = Brushes.Green;
                        break;
                    case 5:
                        fourthColorLabel.Background = Brushes.Blue;
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start_Countdown();


            attempts++;

            string chosenColor1, chosenColor2, chosenColor3, chosenColor4;
            chosenColor1 = firstComboBox.Text;
            chosenColor2 = secondComboBox.Text;
            chosenColor3 = thirdComboBox.Text;
            chosenColor4 = fourthComboBox.Text;

            List<string> chosenColors = new List<string> { chosenColor1, chosenColor2, chosenColor3, chosenColor4 };
            List<string> correctColors = new List<string> { color1, color2, color3, color4};

            for (int i = 0; i < 4; i++)
            {
                Label targetlabel = null;

                switch (i)
                {
                    case 0:
                        targetlabel = firstColorLabel;
                        break;
                    case 1:
                        targetlabel = secondColorLabel;
                        break;
                    case 2:
                        targetlabel = thirdColorLabel;
                        break;
                    case 3:
                        targetlabel = fourthColorLabel;
                        break;
                }

                if (chosenColors[i] == correctColors[i])
                {
                    targetlabel.BorderBrush = Brushes.DarkRed;
                    targetlabel.BorderThickness = new Thickness(5);
                }
                else if (correctColors.Contains(chosenColors[i]))
                {
                    targetlabel.BorderBrush = Brushes.Wheat;
                    targetlabel.BorderThickness = new Thickness(5);
                }
                else
                {
                    targetlabel.BorderBrush = Brushes.Transparent;
                    targetlabel.BorderThickness = new Thickness(0);
                }
            }

            ShowAttempt(chosenColors, correctColors);
            ChangeScore(chosenColors, correctColors);
            WinOrLose(chosenColors, correctColors);

            Mastermind.Title = $"Pogingen: {attempts}";
        }
        private void CodeRandomizer(out string color1, out string color2, out string color3, out string color4)
        {
            //Declareren van een random en een list
            Random color = new Random();
            List<string> colorList = new List<string>();
            string randomColor = "null";

            //For loop die 4 keer loopt om 4 kleuren in de list te zetten
            for (int colorPosition = 1; colorPosition <= 4; colorPosition++)
            {
                int colorNumber = (color.Next(1, 7));
                switch (colorNumber)
                {
                    case 1:
                        randomColor = "Wit";
                        break;
                    case 2:
                        randomColor = "Rood";
                        break;
                    case 3:
                        randomColor = "Orange";
                        break;
                    case 4:
                        randomColor = "Geel";
                        break;
                    case 5:
                        randomColor = "Groen";
                        break;
                    case 6:
                        randomColor = "Blauw";
                        break;
                }

                colorList.Add(randomColor);
            }

            color1 = colorList[0];
            color2 = colorList[1];
            color3 = colorList[2];
            color4 = colorList[3];
        }

        //kijkt waneer de F12+CTRL keys ingedrukt worden
        private void Mastermind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12 && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                ToggleDebug();
            }
        }

        //Maakt debug vissible of invissible
        private void ToggleDebug()
        {
            if (correctCodeTextBox.Visibility == Visibility.Visible)
            {
                correctCodeTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                correctCodeTextBox.Visibility = Visibility.Visible;
            }
        }

        //Decclareren van startTimer en initiazeren van timer
        DateTime startTime = DateTime.Now;
        DispatcherTimer timer = new DispatcherTimer();

        //Deze methode start de countdown met een interval van 1
        private void Start_Countdown()
        {
            timerTextBox.Text = "00";
            timer.Interval = TimeSpan.FromSeconds(1);
            //aanmaken van de Timer_Tick methode
            timer.Tick += Timer_Tick;
            timer.Start();

            startTime = DateTime.Now;
        }

        //De timer tickt iedere seconden en na 10 seconder voert die de methode Stop_Countdown uit
        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan interval = DateTime.Now - startTime;

            timerTextBox.Text = interval.ToString("ss");
            string tien = "10";
            if (interval.ToString("ss") == tien)
            {
                Stop_Countdown();
            }
        }

        //Deze methode stops de countdown en laat de speler weten dat hij zijn beurt verloren heeft
        private void Stop_Countdown()
        {
            timer.Stop();
            MessageBox.Show("Beurt verloren");
            score -= 8;
        }

        private void ShowAttempt(List<string> chosenColors, List<string> correctColors)
        {
            int column = 4;
            for (int i = 0; i < 4; i++)
            {
                Label colorLabel = new Label();
                Grid.SetRow(colorLabel, row);
                Grid.SetColumn(colorLabel, column);
                mastermindGrid.Children.Add(colorLabel);
                colorLabels.Add(colorLabel);
                column++;

                switch (chosenColors[i])
                {
                    case "Wit":
                        colorLabel.Background = Brushes.White;
                            break;
                    case "Rood":
                        colorLabel.Background = Brushes.Red;
                        break;
                    case "Orange":
                        colorLabel.Background = Brushes.Orange;
                        break;
                    case "Geel":
                        colorLabel.Background = Brushes.Yellow;
                        break;
                    case "Groen":
                        colorLabel.Background = Brushes.Green;
                        break;
                    case "Blauw":
                        colorLabel.Background = Brushes.Blue;
                        break;
                }

                if (chosenColors[i] == correctColors[i])
                {
                    colorLabel.BorderBrush = Brushes.DarkRed;
                    colorLabel.BorderThickness = new Thickness(5);
                }
                else if (correctColors.Contains(chosenColors[i]))
                {
                    colorLabel.BorderBrush = Brushes.Wheat;
                    colorLabel.BorderThickness = new Thickness(5);
                }
                else
                {
                    colorLabel.BorderBrush = Brushes.Transparent;
                    colorLabel.BorderThickness = new Thickness(0);
                }

            }
            row++;
        }

        private void WinOrLose(List<string> chosenColors, List<string> correctColors)
        {

            if (chosenColors.SequenceEqual(correctColors))
            {
                MessageBoxResult antwoord = MessageBox.Show($"Score: {score}\nAantal pogingen: {attempts}!\nWilt u noch eens proberen?","Gewonnen!",MessageBoxButton.YesNo);
                attempts--;
                if (antwoord == MessageBoxResult.Yes)
                {
                    GameStart();
                    timer.Stop();
                }
                else
                {
                    Close();
                    timer.Stop();
                }
            }
            else if(attempts > 10)
            {
                MessageBoxResult antwoord = MessageBox.Show("Helaas u pogingen zijn op.\nWilt u noch eens proberen?","Verloren",MessageBoxButton.YesNo);
                attempts--;
                if (antwoord == MessageBoxResult.Yes)
                {
                    GameStart();
                    timer.Stop();
                }
                else
                {
                    Close();
                }
            }
        }

        private void ChangeScore(List<string> chosenColors, List<string> correctColors)
        {

            for (int i = 0; i < 4; i++)
            {
                if (correctColors[i] == chosenColors[i])
                {
                    score -= 0;
                }
                else if (correctColors.Contains(chosenColors[i]))
                {
                    score--;
                }
                else
                {
                    score -= 2;
                }
            }

            scoreTextBox.Text = score.ToString();
        }

        private void Mastermind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult antwoord = MessageBox.Show("Bent u zeker dat u de aplicatie wilt afsluiten?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (antwoord == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void RemoveAttemptLabels()
        {
            foreach(var label in colorLabels)
            {
                mastermindGrid.Children.Remove(label);
            }

            colorLabels.Clear();
        }

        private void ResetChoiceLabels()
        {
            firstComboBox.SelectedIndex = -1;
            firstComboBox.ClearValue(Control.BackgroundProperty);
            firstColorLabel.ClearValue(Control.BackgroundProperty); 
            firstColorLabel.ClearValue(Border.BorderBrushProperty);
            firstColorLabel.ClearValue(Border.BorderThicknessProperty);
;
            secondComboBox.SelectedIndex = -1;
            secondComboBox.ClearValue(Control.BackgroundProperty);
            secondColorLabel.ClearValue(Control.BackgroundProperty);
            secondColorLabel.ClearValue(Border.BorderBrushProperty);
            secondColorLabel.ClearValue(Border.BorderThicknessProperty);

            thirdComboBox.SelectedIndex = -1;
            thirdComboBox.ClearValue(Control.BackgroundProperty);
            thirdColorLabel.ClearValue(Control.BackgroundProperty);
            thirdColorLabel.ClearValue(Border.BorderBrushProperty);
            thirdColorLabel.ClearValue(Border.BorderThicknessProperty);

            fourthComboBox.SelectedIndex = -1;
            fourthComboBox.ClearValue(Control.BackgroundProperty);
            fourthColorLabel.ClearValue(Control.BackgroundProperty);
            fourthColorLabel.ClearValue(Border.BorderBrushProperty);
            fourthColorLabel.ClearValue(Border.BorderThicknessProperty);
        }

    }
}