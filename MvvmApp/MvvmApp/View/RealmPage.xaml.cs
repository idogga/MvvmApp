using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealmPage : ContentPage
    {
        public RealmPage()
        {
            InitializeComponent();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            realmVM.AddRandomUser();
        }
    }
}