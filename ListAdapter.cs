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
    /// <summary>
    /// List adapter.
    /// ListView数据适配器
    /// </summary>
    public class EmployeesAdapter : BaseAdapter<Employee>
    {
        private Activity context = null;

        /// <summary>
        /// 默认构造器
        /// </summary>
        public EmployeesAdapter()
        {
        }

        /// <summary>
        /// 带参构造器
        /// </summary>
        /// <param name="context"></param>
        /// <param name="list"></param>
        public EmployeesAdapter(Activity context)
            : base()
        {
            this.context = context;
        }

        public override int Count
        {
            get { return EmployeeManagement.Init().Employees.Count(); }
        }

        public override Employee this[int position]
        {
            get { return EmployeeManagement.Init().Employees[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var ___count = EmployeeManagement.Init().Employees.Count();

            var item = EmployeeManagement.Init().Employees[position];
            var view = convertView;

            if (convertView == null || !(convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.Main, parent, false);
            }

            var imageItem = view.FindViewById(Resource.Id.imageView_item) as ImageView;
            var tvName = (TextView)view.FindViewById(Resource.Id.textview_top);
            var tvDescrtion = view.FindViewById(Resource.Id.textview_bottom) as TextView;
            var deleteButton = view.FindViewById<ImageButton>(Resource.Id.delete);
            deleteButton.Tag = item.Number;
            view.Tag = item.Number;

            tvName.SetText(item.Name, TextView.BufferType.Normal);

            var lastLog = item.LastCheckLog();

            string lastCheckDescription = "-";
            if (lastLog != null)
            {
                if (lastLog.CheckType == CheckType.IN)
                    imageItem.SetImageResource(Resource.Drawable.red_arrow_100x100_72);
                if (lastLog.CheckType == CheckType.OUT)
                    imageItem.SetImageResource(0);
                lastCheckDescription = lastLog.CheckType + "-" + lastLog.CheckTime.ToString();
            }

            tvDescrtion.SetText(lastCheckDescription, TextView.BufferType.Normal);
            view.Click +=
            (sender, e)
             =>
            {
                View _item = sender as View;
                var employeeCall = new Intent(this.context, typeof(EmployeeLogs));
                employeeCall.PutExtra("Employee", _item.Tag.ToString());
                this.context.StartActivity(employeeCall);
            };
            
            view.FindViewById<ImageButton>(Resource.Id.delete).Click +=
            (sender, e)
             =>
             {
                 ImageButton _item = sender as ImageButton;
                 Console.WriteLine("Delete: " + _item.Tag.ToString());
                 EmployeeManagement.Init().DeleteEmployee(_item.Tag.ToString());

                 NotifyDataSetChanged();
             };

            return view;
        }
        
        public override long GetItemId(int position)
        {
            return position;
        }
    }
}