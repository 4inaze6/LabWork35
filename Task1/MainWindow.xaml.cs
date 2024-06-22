using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "текстовые|*.txt|cs-файлы|*.cs|html-файлы|*.html|css-файлы|*.css|js-файлы|*.js|sql-файлы|*.sql",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Открытие файла",
            };

            if (dialog.ShowDialog().Value != true)
                return;
            ContentTextBox.Text = File.ReadAllText(dialog.FileName);
            Title = dialog.SafeFileName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "текстовые|*.txt|cs-файлы|*.cs|html-файлы|*.html|css-файлы|*.css|js-файлы|*.js|sql-файлы|*.sql",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Сохранение файла",
            };

            if (dialog.ShowDialog().Value != true)
                return;
            File.WriteAllText(dialog.FileName, ContentTextBox.Text);
            MessageBox.Show("Файл успешно сохранен", "Сохранение");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть приложение?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                e.Cancel = true;
        }
    }
}