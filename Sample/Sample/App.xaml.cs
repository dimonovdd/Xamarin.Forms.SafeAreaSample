using Sample.Views;
using Xamarin.Forms;

namespace Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new HomePage();
            MainPage = new NavigationPage(page);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
