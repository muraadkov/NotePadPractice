using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Practice06._06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Timer timer = new Timer(SaveFile, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));
        }
        private void saveTextBox_Click(object sender, RoutedEventArgs e)
        {
            string filepath = @"C:\Users\АдылкановМ.CORP\source\repos\Practice06.06\Practice06.06\bin\Debug\test.txt";
            FileStream file = new FileStream(filepath, FileMode.OpenOrCreate);
            new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Save(file, DataFormats.Text);
        }
        private void SaveFile(object state)
        {
            Random random = new Random();
            var number = random.Next(0, 9999);
            string fileName = $"file_{number}.txt";
            string filepath = $@"C:\Users\АдылкановМ.CORP\source\repos\Practice06.06\Practice06.06\bin\Debug\{fileName}";
            FileStream file = new FileStream(filepath, FileMode.OpenOrCreate);
            new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Save(file, DataFormats.Text);
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string filename = saveFileDialog.FileName + ".txt";
            File.WriteAllText(filename, new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text);
            MessageBox.Show("Файл сохранен", "Успешно!");
        }

        private void OpenDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            string fileText = File.ReadAllText(filename);
            new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text = fileText;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            new PrintDialog().ShowDialog();
        }
    }
}
