using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContactPage : ContentPage
    {
        public AddNewContactPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var context = ((AddNewContactViewModel)BindingContext);
            context.OnUpdate?.Invoke(context.User);
        }
    }
}