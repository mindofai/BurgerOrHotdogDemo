using BurgerOrHotdog.ViewModels;
using Xamarin.Forms;

namespace BurgerOrHotdog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    image.Source = ImageSource.FromUri(new Uri(urlEntry.Text));

        //}


    }
}
