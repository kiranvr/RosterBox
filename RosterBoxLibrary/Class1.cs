﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosterBoxLibrary
{
    public enum ShiftType//TODO: this making it tightly bonded. either this needs to be dynamic or totally be avoided
    {
        S1,
        S2,
        S3
    }

    public class EngineerMgr
    {
        ObservableCollection<Engineer> engineers = new ObservableCollection<Engineer>();

        public ObservableCollection<Engineer> Engineers
        {
            get
            {
                return engineers;
            }

            set
            {
                engineers = value;
            }
        }

        public EngineerMgr()
        {
            this.engineers.Add(new Engineer() { Id = 1, EmpNo = "A123", Name = "Jame", ProfileImagePath = "" });
            this.engineers.Add(new Engineer() { Id = 2, EmpNo = "A223", Name = "Tom", ProfileImagePath = "" });
            this.engineers.Add(new Engineer() { Id = 3, EmpNo = "A323", Name = "Alice", ProfileImagePath = "" });
            this.engineers.Add(new Engineer() { Id = 3, EmpNo = "A32s3", Name = "Bob", ProfileImagePath = "" });
            this.engineers.Add(new Engineer() { Id = 3, EmpNo = "A32e3", Name = "Trude", ProfileImagePath = "" });
        }

    }
    public class ShiftAllocator
    {

    }

    public class ShiftValidator
    {

    }
    public class Engineer
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }

        public string Name { get; set; }
        public string ProfileImagePath { get; set; }

    }

    public class XShift : INotifyPropertyChanged
    {
        public XDay Day { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Type"));
                }
            }
        }

        string type;
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class XDay
    {
        public XWeek Week { get; set; }
        ObservableCollection<XShift> shifts = new ObservableCollection<XShift>();
        public DateTime Date { get; private set; }

        public ObservableCollection<XShift> Shifts
        {
            get
            {
                return shifts;
            }

            set
            {
                shifts = value;
            }
        }

        public DayOfWeek DayOfWeek { get; private set; }

        public XDay(DateTime day)
        {
            this.Date = day;
            this.DayOfWeek = day.DayOfWeek;
        }
        public void AddShift(XShift shift)
        {
            this.Shifts.Add(shift);
            shift.Day = this;
        }

    }
    public class XWeek
    {
        public XWeek()
        {
            // this.Days = new ReadOnlyCollection<XDay>(days);
        }
        public XCycle Cycle { get; set; }
        ObservableCollection<XDay> days = new ObservableCollection<XDay>();
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ObservableCollection<XDay> Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }

        public void AddDay(XDay day)
        {
            this.Days.Add(day);
            day.Week = this;
        }
    }
    public class XCycle
    {
        ObservableCollection<XWeek> weeks = new ObservableCollection<XWeek>();
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ObservableCollection<XWeek> Weeks
        {
            get
            {
                return weeks;
            }

            set
            {
                weeks = value;
            }
        }

        public XCycle()
        {
            //this.Weeks = new ReadOnlyObservableCollection<XWeek>(weeks);
        }
        public void AddWeek(XWeek week)
        {
            this.Weeks.Add(week);
            week.Cycle = this;


        }





    }

    public class XBoard
    {
        ObservableCollection<XCycle> cycles = new ObservableCollection<XCycle>();

        public ObservableCollection<XCycle> Cycles
        {
            get { return cycles; }
            set { cycles = value; }
        }

        public void Generate(DateTime start, DateTime end)
        {
            int i = 0;
            XCycle currentCycle = null;
            XWeek currentWeek = null;


            foreach (DateTime day in EachDay(start, end))
            {

                if (i % 35 == 0)
                {
                    currentCycle = new XCycle() { Id = (i / 35) + 1 };
                    this.Cycles.Add(currentCycle);

                }

                if (i % 7 == 0)
                {
                    currentWeek = new XWeek() { Id = (i / 7) + 1 };
                    currentCycle.AddWeek(currentWeek);
                }

                XDay xday = new XDay(day);
                xday.Shifts.Add(new XShift() { Day = xday, Type = "S1" });
                xday.Shifts.Add(new XShift() { Day = xday, Type = "S2" });
                xday.Shifts.Add(new XShift() { Day = xday, Type = "S3" });
                currentWeek.AddDay(xday);
                i++;
            }

            //this.cycles[0].SillyChildren.Add(new SillyChildern() { SillyChildName = "SILLLYYYYYY" });

        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)//TODO is a utility method/can be moved to helper
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public override string ToString()
        {
            return "its x board";
        }
    }



    public class SillyChildern
    {
        public string SillyChildName { get; set; }
    }
}
