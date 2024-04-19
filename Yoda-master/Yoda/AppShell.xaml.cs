using Yoda.Views;
using Yoda.ViewModels;
namespace Yoda
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Facts", typeof(FactsPage));
        }

    }
}
