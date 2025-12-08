using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace кт16
{
    public partial class MainWindow : Window
    {
        private List<Question> questions;
        private List<RadioButton> answerRadioButtons;

        public MainWindow()
        {
            InitializeComponent();
            InitializeQuestions();
            CreateQuestionControls();
        }

        private void InitializeQuestions()
        {
            questions = new List<Question>
            {
                new Question("Столица Франции?", "Лондон", "Берлин", "Париж", 3),
                new Question("Сколько планет в Солнечной системе?", "8", "9", "7", 1),
                new Question("Самый большой океан?", "Атлантический", "Индийский", "Тихий", 3),
                new Question("Сколько дней в високосном году?", "365", "366", "364", 2),
                new Question("Кто написал 'Войну и мир'?", "Достоевский", "Толстой", "Чехов", 2),
                new Question("Химическая формула воды?", "CO2", "H2O", "O2", 2),
                new Question("Сколько цветов в радуге?", "6", "7", "8", 2),
                new Question("Самая длинная река в мире?", "Амазонка", "Нил", "Янцзы", 1),
                new Question("Сколько часов в сутках?", "12", "24", "36", 2),
                new Question("Кто изобрел телефон?", "Эдисон", "Белл", "Тесла", 2),
                new Question("Сколько сторон у квадрата?", "3", "4", "5", 2),
                new Question("Самая высокая гора в мире?", "Килиманджаро", "Эверест", "Мак-Кинли", 2),
                new Question("Сколько месяцев в году?", "10", "12", "11", 2),
                new Question("Кто нарисовал 'Мона Лизу'?", "Микеланджело", "Да Винчи", "Рафаэль", 2),
                new Question("Сколько секунд в минуте?", "60", "100", "360", 1)
            };
        }

        private void CreateQuestionControls()
        {
            answerRadioButtons = new List<RadioButton>();

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];

              
                var questionBorder = new Border
                {
                    BorderBrush = System.Windows.Media.Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 15),
                    Padding = new Thickness(10),
                    Background = System.Windows.Media.Brushes.WhiteSmoke
                };

                var questionStack = new StackPanel();

               
                var questionText = new TextBlock
                {
                    Text = $"{i + 1}. {question.Text}",
                    FontWeight = FontWeights.Bold,
                    FontSize = 14,
                    Margin = new Thickness(0, 0, 0, 10),
                    TextWrapping = TextWrapping.Wrap
                };
                questionStack.Children.Add(questionText);

                
                var answerGroup = new StackPanel();

                
                var radio1 = CreateRadioButton($"а) {question.Option1}", i, 1);
                var radio2 = CreateRadioButton($"б) {question.Option2}", i, 2);
                var radio3 = CreateRadioButton($"в) {question.Option3}", i, 3);

                answerGroup.Children.Add(radio1);
                answerGroup.Children.Add(radio2);
                answerGroup.Children.Add(radio3);

                questionStack.Children.Add(answerGroup);
                questionBorder.Child = questionStack;
                questionsPanel.Children.Add(questionBorder);

               
                answerRadioButtons.Add(radio1);
                answerRadioButtons.Add(radio2);
                answerRadioButtons.Add(radio3);
            }
        }

        private RadioButton CreateRadioButton(string content, int questionIndex, int optionIndex)
        {
            var radio = new RadioButton
            {
                Content = content,
                FontSize = 13,
                Margin = new Thickness(5, 2, 0, 2),
                Tag = new Tuple<int, int>(questionIndex, optionIndex) 
            };
            return radio;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int correctAnswers = 0;
            int totalQuestions = questions.Count;

            for (int i = 0; i < questions.Count; i++)
            {
                bool questionAnswered = false;
                int selectedAnswer = 0;

               
                for (int j = 0; j < 3; j++)
                {
                    int radioIndex = i * 3 + j;
                    if (answerRadioButtons[radioIndex].IsChecked == true)
                    {
                        questionAnswered = true;
                        var tag = (Tuple<int, int>)answerRadioButtons[radioIndex].Tag;
                        selectedAnswer = tag.Item2;
                        break;
                    }
                }

                
                if (questionAnswered && selectedAnswer == questions[i].CorrectAnswer)
                {
                    correctAnswers++;
                }
            }

            
            ShowResults(correctAnswers, totalQuestions);
        }

        private void ShowResults(int correctAnswers, int totalQuestions)
        {
            double percentage = (double)correctAnswers / totalQuestions * 100;

            resultText.Text = $"Вы ответили правильно на {correctAnswers} из {totalQuestions} вопросов";
            scoreText.Text = $"Правильных ответов: {correctAnswers}";
            percentageText.Text = $"Процент правильных ответов: {percentage:F1}%";

          
            resultsTab.IsEnabled = true;
            tabControl.SelectedItem = resultsTab;
        }

        private void BackToTest_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public int CorrectAnswer { get; set; } 

        public Question(string text, string opt1, string opt2, string opt3, int correct)
        {
            Text = text;
            Option1 = opt1;
            Option2 = opt2;
            Option3 = opt3;
            CorrectAnswer = correct;
        }
    }
}