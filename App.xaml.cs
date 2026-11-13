using Microsoft.Extensions.DependencyInjection;

namespace M_LOGITge25
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var startPage = new StartPage();

            var navPage = new NavigationPage(startPage)
            {
                BackgroundColor = Colors.LightPink,
                BarTextColor = Colors.Black
            };

            return new Window(navPage);
        }
    }
}