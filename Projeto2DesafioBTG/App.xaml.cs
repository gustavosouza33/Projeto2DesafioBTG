using Projeto2DesafioBTG.Models;
using System.Text.Json;

namespace Projeto2DesafioBTG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }


        public static List<Cliente> ListaClientes
        {
            get
            {
                string jsonClientes = Preferences.Get("ListaClientes", string.Empty);
                List<Cliente> listaClientes = string.IsNullOrEmpty(jsonClientes) ? new List<Cliente>() : JsonSerializer.Deserialize<List<Cliente>>(jsonClientes);
                return listaClientes;
            }
            set
            {
                Preferences.Set("ListaClientes", JsonSerializer.Serialize(value));
            }
        }
    }

}
