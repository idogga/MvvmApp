using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRotationClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RotationPage()));
        }

        private async void OnTextClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TextPage()));
        }

        private async void OnRealmClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RealmPage()));
        }

        private async void OnRealmMVVMClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RealmMVVMPage()));
        }
    }
}