
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
using RosterBox.ViewModels;

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//checking if vm update reflects in UI
            XBoardViewModel vm = (XBoardViewModel)this.DataContext;
            vm.Xboard.Cycles[0].Weeks[0].Days[0].Shifts[0].Type = "I-" + DateTime.Now.Second;

            //commented-1

            
        }
    }
}
