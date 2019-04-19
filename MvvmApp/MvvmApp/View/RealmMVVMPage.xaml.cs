using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealmMVVMPage : ContentPage
    {
        public RealmMVVMPage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                ((ContactsViewModel)BindingContext).OpenCommand.Execute(e.SelectedItem);
            }
        }
    }
}