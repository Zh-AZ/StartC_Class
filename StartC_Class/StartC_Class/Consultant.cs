using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartC_Class
{
    class Consultant : INotifyPropertyChanged
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _numberPhone;
        private string _numberPassport;
        private string _change;

        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(" Фамилия");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.firstName)));
            }
        }
        public string middleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged(" Имя");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.middleName)));
            }
        }
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(" Отчество");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.lastName)));
            }
        }
        public string numberPhone
        {
            get { return _numberPhone; }
            set
            {
                _numberPhone = value;
                OnPropertyChanged(" Номер телефона");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.numberPhone)));
            }
        }
        public string numberPassport
        {
            get { return _numberPassport; }
            set
            {
                _numberPassport = value;
                OnPropertyChanged(" Номер паспорта");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.numberPassport)));
            }
        }
        public string hidePassport { get; } = "**********";

        public string change
        {
            get { return _change; }
            set
            {
                _change = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.change)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                change = String.Empty;
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                change += Time();
                change += prop;
            }
        }

        public Consultant(string firstName, string middleName, string lastName, string numberPhone, string numberPassport)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.numberPhone = numberPhone;
            this.numberPassport = numberPassport;
        }

        public virtual string Time()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            change = dateTime.ToString("g");
            return change;
        }
    }
}
