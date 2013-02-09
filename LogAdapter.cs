﻿using System;
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
    public class LogAdapter : BaseAdapter<CheckLogs>
    {
        private Activity context = null;
        public List<CheckLogs> list = null;
        public Employee employee = null;

        /// <summary>
        /// 默认构造器
        /// </summary>
        public LogAdapter()
        {
        }

        /// <summary>
        /// 带参构造器
        /// </summary>
        /// <param name="context"></param>
        /// <param name="list"></param>
        public LogAdapter(Activity context, Employee employee)
            : base()
        {
            this.employee = employee;
            this.context = context;
            this.list = employee.Logs;
        }

        public override int Count
        {
            get { return this.list.Count; }
        }

        public override CheckLogs this[int position]
        {
            get { return this.list[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.list[position];
            var view = convertView;

            if (convertView == null || !(convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.Main, parent, false);
            }

            var imageItem = view.FindViewById(Resource.Id.imageView_item) as ImageView;
            var tvName = (TextView)view.FindViewById(Resource.Id.textview_top);
            var tvDescrtion = view.FindViewById(Resource.Id.textview_bottom) as TextView;

            tvName.SetText(item.CheckTime.ToString(), TextView.BufferType.Normal);

            //var lastLog = item.LastCheckLog();

            string lastCheckDescription = "-";
            //if (lastLog != null)
           // {
                if (item.CheckType == CheckType.IN)
                    imageItem.SetImageResource(Resource.Drawable.red_arrow_100x100_72);
                lastCheckDescription = item.CheckType + "-" + item.CheckTime.ToString();
            //}

            //tvDescrtion.SetText(lastCheckDescription, TextView.BufferType.Normal);
           /*
            view.Click += delegate(object sender, EventArgs e)
            {
                Toast.MakeText(context, ((TextView)tvName).Text, ToastLength.Long).Show();
            };
            * */

            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}