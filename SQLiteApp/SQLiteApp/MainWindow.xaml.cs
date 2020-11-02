using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
            DataAccess.AddData("Tarit");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

           // DataAccess.AddData(inputTxt.ToString());
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
           
            string Data = "";
            foreach (string inside in DataAccess.GetData())
            {
                Data = Data + " " + inside + "\n";
            }
            MessageBox.Show(Data);
        }
    }
}
