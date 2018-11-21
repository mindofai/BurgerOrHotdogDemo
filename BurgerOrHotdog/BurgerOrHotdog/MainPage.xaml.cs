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

    }
}
