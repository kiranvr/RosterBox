using RosterBoxLibrary;
using RosterBoxLibrary.ViewModels;
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

namespace RosterBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //XBoard xboard = new XBoard();
            //xboard.Generate(new DateTime(2016, 2, 1), new DateTime(2016, 8, 1));
            //this.DataContext = new XBoardViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
