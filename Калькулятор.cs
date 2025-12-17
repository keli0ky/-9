using System;
using System.Windows;

namespace Калькулятор
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private double firstNumber = 0;
        private string operation = "";
        private bool isNewInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;

            if (isNewInput)
            {
                currentInput = button.Content.ToString();
                isNewInput = false;
            }
            else
            {
                currentInput += button.Content.ToString();
            }

            displayTextBox.Text = currentInput;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                firstNumber = double.Parse(currentInput);
                operation = button.Content.ToString();
                currentInput = "";
                isNewInput = true;
            }
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentInput))
            {
                double secondNumber = double.Parse(currentInput);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            displayTextBox.Text = "Ошибка";
                            currentInput = "";
                            operation = "";
                            isNewInput = true;
                            return;
                        }
                        break;
                }

                displayTextBox.Text = result.ToString();
                currentInput = result.ToString();
                operation = "";
                isNewInput = true;
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            firstNumber = 0;
            operation = "";
            isNewInput = true;
            displayTextBox.Text = "0";
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                if (string.IsNullOrEmpty(currentInput))
                {
                    currentInput = "0.";
                }
                else
                {
                    currentInput += ".";
                }
                displayTextBox.Text = currentInput;
                isNewInput = false;
            }
        }
    }
}