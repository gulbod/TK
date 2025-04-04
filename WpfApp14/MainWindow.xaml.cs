using System;
using System.Windows;

namespace WpfApp14
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate(Task1TextBox.Text, Task2TextBox.Text, Task3TextBox.Text, Task4TextBox.Text);
        }

        public static class CalculatorService
        {
            public static int ValidateInput(string input, int maxValue)
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Поле не может быть пустым");

                if (!int.TryParse(input, out int value))
                    throw new ArgumentException("Введите целое число");

                if (value < 0 || value > maxValue)
                    throw new ArgumentException($"Значение должно быть от 0 до {maxValue}");

                return value;
            }

            public static string CalculateGrade(int total)
            {
                if (total >= 70) return "5 (отлично)";
                if (total >= 40) return "4 (хорошо)";
                if (total >= 20) return "3 (удовлетворительно)";
                return "2 (неудовлетворительно)";
            }
        }

        public bool Calculate(string t1, string t2, string t3, string t4)
        {
            try
            {
                int task1 = CalculatorService.ValidateInput(t1, 10);
                int task2 = CalculatorService.ValidateInput(t2, 50);
                int task3 = CalculatorService.ValidateInput(t3, 30);
                int task4 = CalculatorService.ValidateInput(t4, 10);

                int total = task1 + task2 + task3 + task4;
                string grade = CalculatorService.CalculateGrade(total);

                ResultTextBlock.Text = $"Сумма баллов: {total}\nОценка: {grade}";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
