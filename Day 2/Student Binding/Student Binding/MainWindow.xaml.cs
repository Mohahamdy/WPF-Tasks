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

namespace Student_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Student> students = new List<Student>()
            {
                new Student() {ID = 1, Name ="Mohamed" , Grade = 100,Image ="1.jpg"},
                new Student() {ID = 2, Name ="Ahmed" , Grade = 80,Image = "2.jpg"},
                new Student() {ID = 3, Name ="Abdallah" , Grade = 90,Image = "3.jpg"},
                new Student() {ID = 4, Name ="Allam" , Grade = 50,Image = "4.jpg"},
                new Student() {ID = 5, Name ="Shadi" , Grade = 40,Image = "5.jpg"},
                new Student() {ID = 6, Name ="Body" , Grade = 70,Image = "1.jpg"},
                new Student() {ID = 7, Name ="Hossam" , Grade = 60,Image = "2.jpg"},
                new Student() {ID = 8, Name ="Ali" , Grade = 55,Image = "3.jpg"},
                new Student() {ID = 9, Name ="Mohsen" , Grade = 44,Image = "4.jpg"},
            };

            list.ItemsSource = students;

        }
    }
}