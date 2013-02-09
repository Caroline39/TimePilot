using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using TimePilot.Models;

namespace TimePilot
{
    [Activity(Label = "TimePilot", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // ???????
            InitListData();
        }

        /// <summary>
        /// ???????
        /// </summary>
        public void InitListData()
        {
            this.ListAdapter = new EmployeesAdapter(this);
        }
        /*
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var employee = EmployeeManagement.Init().Employees[position];
            var employeeCall = new Intent(this, typeof(EmployeeLogs));
            employeeCall.PutExtra("Employee",employee.Name);
            StartActivity(employeeCall);
        }
        */
	}
}