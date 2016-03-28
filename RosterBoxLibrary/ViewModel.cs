using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosterBoxLibrary.ViewModels
{
    public class XBoardViewModel: INotifyPropertyChanged
    {
        XBoard xboard = new XBoard();
        public XBoardViewModel()
        {
            Xboard.Generate(new DateTime(2016, 2, 1), new DateTime(2016, 8, 1));

        }

        public XBoard Xboard
        {
            get
            {
                return xboard;
            }

            set
            {
                xboard = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
