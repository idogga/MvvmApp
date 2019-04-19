using System;

namespace MvvmApp
{
    internal class AddNewContactViewModel
    {
        public UserRealm User { get; set; }

        public AddNewContactViewModel(UserRealm user)
        {
            this.User = user;
        }

        public Action<UserRealm> OnUpdate { get; set; }
    }
}