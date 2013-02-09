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
    public class Employee
    {
        public Employee()
        {
            Logs = new List<CheckLogs>();
            Name = "";
            Number = "";
            Active = true;
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public bool Active { get; set; }
        public double TotleHours
        {
            get
            {
                if (Logs == null) return 0;
                return Logs.Sum(L => L.Hours);
            }
        }

        public void AddLog(CheckType type, DateTime datetime)
        {
            new CheckLogs(this, type, datetime);
        }

        public CheckType CurrentType
        {
            get
            {
                if (Logs.Count == 0) return CheckType.OUT;

                return Logs.OrderByDescending(L => L.CheckTime).FirstOrDefault().CheckType;
            }
        }

        public List<CheckLogs> Logs { get; set; }
        public CheckLogs LastCheckLog()
        {
            return Logs.OrderByDescending(L => L.CheckTime).FirstOrDefault();
        }
    }
}