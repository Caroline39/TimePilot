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
using TimePilot.Models;

namespace TimePilot
{
    [Activity(Label = "Employee Logs")]
    public class EmployeeLogs : ListActivity
    {
        public string name = "";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.name = Intent.GetStringExtra("employee") ?? "DATA not available";

             
            InitListData();
        }

        public void InitListData()
        {
            Employee employee = new Employee() { Name = this.name, Number = "2345" };

            employee.AddLog(CheckType.IN, DateTime.Now.AddHours(-15));
            employee.AddLog(CheckType.OUT, DateTime.Now.AddHours(-12));
            employee.AddLog(CheckType.IN, DateTime.Now.AddHours(-7));
            employee.AddLog(CheckType.OUT, DateTime.Now.AddHours(-5));
            employee.AddLog(CheckType.IN, DateTime.Now);

            this.ListAdapter = new LogAdapter(this, employee);
        }
    }
}