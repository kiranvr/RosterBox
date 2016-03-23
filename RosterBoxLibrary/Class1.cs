using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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



    }

    public class XShift
    {
        public XDay Day { get; set; }
        public string Type { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }

    public class XDay
    {
        public XWeek Week { get; set; }
        List<XShift> shifts = new List<XShift>();
        public DateTime Date { get; set; }
        public ReadOnlyCollection<XShift> Shifts = null;
        public XDay()
        {
            this.shifts = new List<XShift>(shifts);
        }
        public void AddShift(XShift shift)
        {
            this.shifts.Add(shift);
            shift.Day = this;
        }

    }
    public class XWeek
    {
        public XWeek()
        {
            this.Days = new ReadOnlyCollection<XDay>(days);
        }
        public XCycle Cycle { get; set; }
        List<XDay> days = new List<XDay>();
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReadOnlyCollection<XDay> Days = null;

        public void AddDay(XDay day)
        {
            this.days.Add(day);
            day.Week = this;
        }
    }
    public class XCycle
    {
        List<XWeek> weeks = new List<XWeek>();
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReadOnlyCollection<XWeek> Weeks = null;
        public XCycle()
        {
            this.Weeks = new ReadOnlyCollection<XWeek>(weeks);
        }
        public void AddWeek(XWeek week)
        {
            this.weeks.Add(week);
            week.Cycle = this;
        }

    }

    public class XBoard
    {
        List<XCycle> cycles = new List<XCycle>();

        internal List<XCycle> Cycles
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
                i++;
                if (i == 1 || i % 36 == 0)
                {
                    currentCycle = new XCycle() { Id = (i / 35) + 1 };
                    this.Cycles.Add(currentCycle);

                }

                if (i == 1 || i % 8 == 0)
                {
                    currentWeek = new XWeek() { Id = (i / 7) + 1 };
                    currentCycle.AddWeek(currentWeek);
                }

                XDay xday = new XDay() { Date = day };
                currentWeek.AddDay(xday);
            }
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)//TODO is a utility method/can be moved to helper
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

    }
}
