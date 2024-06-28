using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WordCountApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCountClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputText = txtInput.Text.Trim();
                if (string.IsNullOrEmpty(inputText))
                {
                    MessageBox.Show("Введите текст для подсчета повторений слов.");
                    return;
                }

                // Разбиваем строку на слова
                string[] words = inputText.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Словарь для хранения слов и их позиций
                Dictionary<string, List<int>> wordPositions = new Dictionary<string, List<int>>();

                // Заполняем словарь
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    if (!wordPositions.ContainsKey(word))
                    {
                        wordPositions[word] = new List<int>();
                    }

                    wordPositions[word].Add(i + 1); // Добавляем позицию, учитывая её от 1 до N
                }

                // Формируем результат для вывода
                List<string> results = new List<string>();
                foreach (var kvp in wordPositions)
                {
                    results.Add($"{kvp.Key}: {kvp.Value.Count}");
                }

                // Выводим результат в текстовый блок
                txtOutput.Text = string.Join(Environment.NewLine, results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
