using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintUsingInk
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

        private void OnColorChanged(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Red":
                    inkCan.DefaultDrawingAttributes.Color = Colors.Red;
                    break;
                case "Green":
                    inkCan.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
                case "Blue":
                    inkCan.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Magenta":
                    inkCan.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;

            }
        }

        private void OnModeChanged(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Ink":
                    inkCan.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    inkCan.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Erase":
                    inkCan.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "Erase by stroke":
                    inkCan.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

            }
        }

        private void OnSizeChanged(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Small":
                    inkCan.DefaultDrawingAttributes.Width = 4;
                    inkCan.DefaultDrawingAttributes.Height = 4;
                    break;
                case "Normal":
                    inkCan.DefaultDrawingAttributes.Width = 8;
                    inkCan.DefaultDrawingAttributes.Height = 8;
                    break;
                case "Large":
                    inkCan.DefaultDrawingAttributes.Width = 12;
                    inkCan.DefaultDrawingAttributes.Height = 12;
                    break;
            }
        }

        private void OnShapeChanged(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Content.ToString();

            switch (content)
            {
                case "Ellipse":
                    inkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;
                case "Rectangle":
                    inkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;
            }
        }

        private void clickNew(object sender, RoutedEventArgs e)
        {
            inkCan.Strokes.Clear();
        }

        private void clickCut(object sender, RoutedEventArgs e)
        {
            inkCan.CutSelection();
        }

        private void clickCopy(object sender, RoutedEventArgs e)
        {
            inkCan.CopySelection();
        }

        private void clickPast(object sender, RoutedEventArgs e)
        {
            inkCan.Paste();
        }

        private void clickSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog FileDialog = new SaveFileDialog();
            bool? result = FileDialog.ShowDialog();
            if (result == true)
            {
                using (FileStream fs = new FileStream(FileDialog.FileName, FileMode.Create))
                {
                    XamlWriter.Save(inkCan, fs);
                }
            }
            else
            {
                MessageBox.Show("Can't Get the File Path","Can Not Save",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void clickLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    InkCanvas loadedInkCanvas = (InkCanvas)XamlReader.Load(fs);
                    inkCan.Strokes = loadedInkCanvas.Strokes;
                }
            }
            else
            {
                MessageBox.Show("Can't Get the File Path", "Can Not Load", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}