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

namespace Show_Data
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

        private void OnClickOk(object sender, RoutedEventArgs e)
        {

            string informatinMessage =
            "You have enterd: \n" +
            "Name= " + firstName_txt.Text + "" + lastName_txt.Text + "\n" +
            "Gender= " + Gender_txt.Text + "\n" +
            "Adress= " + Adress_txt.Text + "\n" +
            "Phone= " + phone_txt.Text + "\n" +
            "Mobile= " + mobile_txt.Text + "\n" +
            "Email= " + email_txt.Text + "\n" +
            "Job Title= " + jobTitle_txt.Text + "";

            MessageBoxResult messageBoxResult = MessageBox.Show(informatinMessage, "User Information",MessageBoxButton.OKCancel,MessageBoxImage.Information);

            if(messageBoxResult == MessageBoxResult.OK)
            {
                MessageBox.Show("Data Saved Successfully", "Saving");
            }
            else
            {
                ClearAllTextBox();
            }
        }

        private void OnClickCancle(object sender, RoutedEventArgs e)
        {
            ClearAllTextBox();
        }

        private void ClearAllTextBox()
        {
            foreach(Control c in Grid.Children)
            {
                if(c is TextBox)
                {
                    TextBox txtBox = (TextBox)c;
                    txtBox.Clear();
                }
            }
        }
    }
}