using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using Projeto2DesafioBTG.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projeto2DesafioBTG.ViewModels
{
    public class VisualizarClienteViewModel : BaseViewModel
    {
        private readonly IClienteService _clienteService;
        private ObservableCollection<Cliente> clientesCollection { get; set; }
        public ObservableCollection<Cliente> ClientesCollection
        {
            get
            {
                return clientesCollection;
            }
            set
            {
                clientesCollection = value;
                OnPropertyChanged(nameof(ClientesCollection));
            }
        }

        private ObservableCollection<Cliente> clientesCollectionPesquisa { get; set; }
        public ObservableCollection<Cliente> ClientesCollectionPesquisa
        {
            get
            {
                return clientesCollectionPesquisa;
            }
            set
            {
                clientesCollectionPesquisa = value;
                OnPropertyChanged(nameof(ClientesCollectionPesquisa));
            }
        }
        private bool isVisibleClvClientes;
        public bool IsVisibleClvClientes
        {
            get
            {
                return isVisibleClvClientes;
            }
            set
            {
                isVisibleClvClientes = value;
                OnPropertyChanged(nameof(IsVisibleClvClientes));
            }
        }

        private bool isVisibleLblNenhumCliente;
        public bool IsVisibleLblNenhumCliente
        {
            get
            {
                return isVisibleLblNenhumCliente;
            }
            set
            {
                isVisibleLblNenhumCliente = value;
                OnPropertyChanged(nameof(IsVisibleLblNenhumCliente));
            }
        }

        private string textSrbPesquisa = "";
        public string TextSrbPesquisa
        {
            get
            {
                return textSrbPesquisa;
            }
            set
            {
                textSrbPesquisa = value;
                OnPropertyChanged(nameof(TextSrbPesquisa));
            }
        }

        private System.Collections.IEnumerable itemsSourceClvClientes;

        public System.Collections.IEnumerable ItemsSourceClvClientes
        {
            get
            {
                return itemsSourceClvClientes;
            }

            set
            {
                itemsSourceClvClientes = value;
                OnPropertyChanged(nameof(ItemsSourceClvClientes));
            }
        }

        public ICommand ComandoIncluir { get; set; }
        public ICommand ComandoEditar { get; set; }
        public ICommand ComandoExcluir { get; set; }
        public VisualizarClienteViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
            ComandoIncluir = new Command(() => { AppShell.Current.GoToAsync(nameof(IncluirClientePage)); });
            ComandoEditar = new Command(EditarCliente);
            ComandoExcluir = new Command(ExcluirCliente);
        }

        public void CarregarListaClientes()
        {
            ClientesCollection = new ObservableCollection<Cliente>(App.ListaClientes);
            ClientesCollectionPesquisa = new ObservableCollection<Cliente>();
            IsVisibleClvClientes = ClientesCollection.Count > 0;
            IsVisibleLblNenhumCliente = !isVisibleClvClientes;
            ItemsSourceClvClientes = ClientesCollection;
            TextSrbPesquisa = string.Empty;
        }

        private async void EditarCliente(object item)
        {
            var cliente = (Cliente)item;
            if (cliente != null)
            {
                var navigationParameter = new Dictionary<string, object> { { "Cliente", cliente } };
                await AppShell.Current.GoToAsync(nameof(EditarClientePage), navigationParameter);
            }
        }
        private async void ExcluirCliente(object item)
        {
            var cliente = (Cliente)item;
            if (cliente != null)
            {
                var resposta = await Shell.Current.DisplayAlert("Alerta", $"Tem certeza que deseja excluir o cliente {cliente.Name} {cliente.LastName}?", "Sim", "Não");
                if (resposta == true)
                {
                  var excluido =  _clienteService.ExcluirCliente(cliente);
                    if (excluido)
                    {
                        CarregarListaClientes();
                        await Shell.Current.DisplayAlert("", $"Cliente excluído com sucesso!", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("", $"Falha ao excluir cliente.", "OK");
                    }
                }
            }
        }

        public void PesquisarCliente(string nome)
        {
            if (ClientesCollection != null && ClientesCollection.Count > 0)
            {
                if (!string.IsNullOrEmpty(textSrbPesquisa))
                {
                   ClientesCollectionPesquisa.Clear();


                    var resultado = FiltrarClienteNaLista(nome);
                    foreach (var item in resultado)
                    {
                       ClientesCollectionPesquisa.Add(item);
                    }

                   ItemsSourceClvClientes = ClientesCollectionPesquisa;
                }
                else
                {
                    ItemsSourceClvClientes = ClientesCollection;
                }
            }
        }

        public List<Cliente> FiltrarClienteNaLista(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return ClientesCollection.Where(f => f.Name.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }

    }
}
