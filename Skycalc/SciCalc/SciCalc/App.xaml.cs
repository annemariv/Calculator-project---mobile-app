using SciCalc.Views;

namespace SciCalc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new CalculatorPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}