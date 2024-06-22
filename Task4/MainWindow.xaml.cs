using Microsoft.Win32;
using System.Windows;

namespace Task4
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
                Filter = "растровые|*.png; *.jpg; *.jpeg; *.bmp|все файлы|*.*",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выбор изображений",
                Multiselect = true,
            };

            if (dialog.ShowDialog() != true)
                return;
            ImagesListView.ItemsSource = dialog.FileNames;
        }
    }
}