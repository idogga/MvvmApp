using Realms;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MvvmApp
{
    internal class ContactsViewModel
    {
        private readonly Realm _realm;

        public IEnumerable<UserRealm> Users { get; }
        public Command<UserRealm> AddOrUpdateUserCommand { get; }
        public Command<UserRealm> OpenCommand { get; }

        public ContactsViewModel()
        {
            _realm = Realm.GetInstance("book.realm");
            Users = _realm.All<UserRealm>().OrderBy(u => u.Surname);
            AddOrUpdateUserCommand = new Command<UserRealm>(AddOrUpdateUser);
            OpenCommand = new Command<UserRealm>(Open);
        }

        private void Open(UserRealm user)
        {
            var userVM = new AddNewContactViewModel(user);
            userVM.OnUpdate = AddOrUpdateUser;
            NavigationService.Navigate(userVM);
        }

        private void AddOrUpdateUser(UserRealm user)
        {
            if (user == null)
            {
                user = new UserRealm();
                _realm.Write(() => _realm.Add(user));
            }
            else
            {
                _realm.Write(() => _realm.Add(user, true));
            }
        }
    }
}
