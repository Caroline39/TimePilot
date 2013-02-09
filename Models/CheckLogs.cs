using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TimePilot.Models
{
    public enum CheckType
    {
        IN = 0,
        OUT = 1,
    }

    public class CheckLogsException : Exception
    {

    }

    public class CheckLogs
    {
        public CheckLogs(Employee employee, CheckType CheckType, DateTime CheckTime)
        {
            if (employee == null) throw new CheckLogsException();
            if (employee.Logs == null)
            {
                employee.Logs = new List<CheckLogs>();
            }

            this.CheckTime = CheckTime;
            this.CheckType = CheckType;

            if (this.CheckType == CheckType.OUT)
            {

                var item = employee.Logs.Where(L => L.CheckType == CheckType.IN).OrderBy(L => L.CheckTime).LastOrDefault();

                if (item != null)
                {
                    Hours = (CheckTime - item.CheckTime).Minutes / 60;
                }
            }

            employee.Logs.Add(this);
        }


        public CheckType CheckType { get; set; }
        public DateTime CheckTime { get; set; }
        public double Hours { get; set; }
    }
}