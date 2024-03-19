using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace MarkDownNote
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "README";
            saveFileDialog.Filter = "MarkDown file (*.md)|*.md";
            if (saveFileDialog.ShowDialog() == true)
            {
                using(StreamWriter sw=new StreamWriter(saveFileDialog.FileName)) 
                {
                    TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                    sw.WriteLine(textRange.Text);
                }
                MessageBox.Show("파일이 저장되었습니다.");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("내용을 지우시겠습니까?", "경고", MessageBoxButton.YesNo);
            if (msgResult == MessageBoxResult.Yes)
            {
                richTextBox.SelectAll();
                richTextBox.Selection.Text = "";
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "MarkDown file (*.md)|*.md";
            if(openFileDialog.ShowDialog() == true)
            {
                richTextBox.SelectAll();
                richTextBox.Selection.Text = "";

                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    richTextBox.AppendText(streamReader.ReadToEnd());
                }
            }
        }
    }
}