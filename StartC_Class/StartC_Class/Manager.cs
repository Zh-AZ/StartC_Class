using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartC_Class
{
    class Manager : Consultant
    {
        private string _change;
        public new string change
        {
            get { return _change; }
            set
            {
                _change = value;
                base.change = base.change + change;
                OnPropertyChanged(" (Менеджер)");
                ManagerPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.change)));
            }
        }

        public event PropertyChangedEventHandler ManagerPropertyChanged;
        public override void OnPropertyChanged(string prop)
        {
            if (ManagerPropertyChanged != null)
            {
                change = String.Empty;
                ManagerPropertyChanged(this, new PropertyChangedEventArgs(prop));
                change += Time();
                change += prop + " (Менеджер)";
            }
        }

        public Manager(string firstName, string middleName, string lastName, string numberPhone, string numberPassport)
            : base(firstName, middleName, lastName, numberPhone, numberPassport) { }


        public override string Time()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            change = dateTime.ToString("g");
            return change;
        }
    }
}
