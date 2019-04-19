using System.ComponentModel;

namespace MvvmApp
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public UserRealm ToUserRealm()
        {
            return new UserRealm() { Age = Age, Surname = Surname, Name = Name };
        }
    }

    public class UserView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname = "";
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private int _age = 0;
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    _age = 0;
                }
                else if (value > 121)
                {
                    _age = 121;
                }
                else
                {
                    _age = value;
                }

                OnPropertyChanged(nameof(Age));
            }
        }

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public UserRealm ToUserRealm()
        {
            return new UserRealm() { Age = Age, Surname = Surname, Name = Name };
        }
    }

    public class UserRealm : Realms.RealmObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public UserView ToUser()
        {
            return new UserView() { Age = Age, Name = Name, Surname = Surname };
        }
    }
}
