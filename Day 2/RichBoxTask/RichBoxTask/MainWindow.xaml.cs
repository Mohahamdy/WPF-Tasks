using System.Reflection.Metadata;
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
using static System.Net.Mime.MediaTypeNames;

namespace RichBoxTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rBoxText.AppendText("Default starting Text");
            rBoxText.Focus();
        }

        private void OnCheckTextAlignment(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Left":
                    rBoxText.Document.TextAlignment = TextAlignment.Left;
                    break;
                case "Center":
                    rBoxText.Document.TextAlignment = TextAlignment.Center;
                    break;
                case "Right":
                    rBoxText.Document.TextAlignment = TextAlignment.Right;
                    break;
            }

            rBoxText.Focus();
        }

        private void OnCheckReadOrWrite(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Editable":
                    rBoxText.IsReadOnly = false;
                    break;
                case "Read Only":
                    rBoxText.IsReadOnly = true;
                    break;
            }

            rBoxText.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rBoxText.Document.Blocks.Clear();
            rBoxText.Document.Blocks.Add(new Paragraph(new Run("Replace default text with initial text value")));
            rBoxText.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rBoxText.SelectAll();
            rBoxText.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rBoxText.Document.Blocks.Clear();
            rBoxText.Focus();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string text = rBoxText.Selection.Text; 
            if(text == "")
            {
                MessageBox.Show("Please select your Text First","Focus");
            }
            else
            {
                rBoxText.Cut();
                MessageBox.Show($"Cut: {text}","DONE");
                rBoxText.Focus();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            rBoxText.Paste();
            rBoxText.Focus();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            rBoxText.Undo();
            rBoxText.Focus();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                Run run = new Run("*** prpended text ***");
                TextRange textRange = new TextRange(rBoxText.Document.ContentStart, rBoxText.Document.ContentEnd);
                rBoxText.CaretPosition.Paragraph.Inlines.InsertBefore(rBoxText.CaretPosition.Paragraph.Inlines.FirstInline, run);
            }
            catch (Exception)
            {
                rBoxText.AppendText("*** prpended text ***");
            }
       
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            rBoxText.AppendText("*** appended text ***");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            rBoxText.CaretPosition.InsertTextInRun("*** inserted text ***");
        }
    }
}