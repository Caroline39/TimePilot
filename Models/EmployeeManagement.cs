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
    public class EmployeeManagement
    {
        static EmployeeManagement _init = null;
        public static EmployeeManagement Init()
        {
            if (_init == null)
            {
                _init = new EmployeeManagement();
            }

            return _init;
        }

        private EmployeeManagement()
        {
            // TODO: 


            _employees = new List<Employee>()
            {
                new Employee() { Name = "Caroline",Number = "1345"}	,
                new Employee() { Name = "John",Number = "2345"}	,
                new Employee() { Name = "Animax",Number = "3345"}	,
                new Employee() { Name = "Jim",Number = "4345"}	,
                new Employee() { Name = "Steven",Number = "5345"}	,
                new Employee() { Name = "Jim",Number = "6345"}	,
                new Employee() { Name = "Alexa",Number = "7345"}	,
                new Employee() { Name = "Collin",Number = "8345"}	
            };

            _employees[0].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[1].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[1].AddLog(CheckType.OUT, DateTime.Now);
            _employees[2].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[2].AddLog(CheckType.OUT, DateTime.Now);
            _employees[3].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[4].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[4].AddLog(CheckType.OUT, DateTime.Now);
            _employees[5].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[6].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
            _employees[7].AddLog(CheckType.IN, DateTime.Now.AddHours(-10));
        }

        public void SaveData()
        {
            //TODO:
        }

        private List<Employee> _employees { get; set; }
        public List<Employee> Employees
        {
            get
            {
                if (_employees == null)
                    return new List<Employee>();
                return _employees.Where(L => L.Active).ToList();
            }
        }
        public void AddEmployee(string Name, string Number)
        {
            var item = new Employee();
            item.Name = Name;
            item.Number = Number;

            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(item);
        }
        public void DeleteEmployee(string Number)
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            var items = _employees.Where(L => L.Number == Number);
            foreach (var _item in items)
            {
                _item.Active = false;
            }
        }

    }
}
