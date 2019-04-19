using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmApp
{
    public class UserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Random _rnd = new Random(100);

        private User _user;

        public UserVM()
        {
            _user = new User();
            UpdateCommand = new Command(UpdateDataByRandom);
        }

        private void UpdateDataByRandom()
        {
            Name = "ИМЯ №" + _rnd.Next();
            Age = _rnd.Next();
            Surname = "Фамилия №" + _rnd.Next();
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                if (_user.Name != value)
                {
                    _user.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Surname
        {
            get { return _user.Surname; }
            set
            {
                if (_user.Surname != value)
                {
                    _user.Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public int Age
        {
            get { return _user.Age; }
            set
            {
                if (_user.Age != value)
                {
                    _user.Age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public ICommand UpdateCommand { get; private set; }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
