using Realms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MvvmApp
{
    internal class RealmListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Random rnd = new Random(100);
        private Realm _db;

        private ObservableCollection<UserView> _phoneBook = new ObservableCollection<UserView>();
        public ObservableCollection<UserView> PhoneBook
        {
            get => _phoneBook;
            set
            {
                _phoneBook = value;
                OnPropertyChanged(nameof(PhoneBook));
            }
        }


        public RealmListVM()
        {
            _db = Realm.GetInstance("book.realm");
            if (_db.All<UserRealm>().Count() > 0)
            {
                var select = _db.All<UserRealm>().ToList();
                var list = select.Select(x => x.ToUser()).ToList();
                PhoneBook = new ObservableCollection<UserView>(list);
            }
        }

        internal void AddRandomUser()
        {
            var user = new UserRealm();
            _db.Write(() =>
            {
                user.Name = "Имя №" + rnd.Next();
                user.Age = rnd.Next();
                user.Surname = "Фамилия №" + rnd.Next();
                _db.Add(user);
            });
            PhoneBook.Add(user.ToUser());
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
