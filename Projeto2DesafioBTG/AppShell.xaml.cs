using Projeto2DesafioBTG.Views;

namespace Projeto2DesafioBTG
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
            Routing.RegisterRoute(nameof(IncluirClientePage), typeof(IncluirClientePage));
            Routing.RegisterRoute(nameof(EditarClientePage), typeof(EditarClientePage));
        }
    }
}
