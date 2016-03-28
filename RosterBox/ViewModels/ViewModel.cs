using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosterBoxLibrary;

namespace RosterBox.ViewModels
{
    public class XBoardViewModel: INotifyPropertyChanged
    {
        XBoard xboard = new XBoard();
        EngineerMgr mgr = new EngineerMgr();
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

        public EngineerMgr Mgr
        {
            get
            {
                return mgr;
            }

            set
            {
                mgr = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

 
}
