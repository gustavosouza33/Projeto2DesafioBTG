using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Projeto2DesafioBTG.ViewModels
{
    [QueryProperty(nameof(Cliente), "Cliente")]
    public class EditarClienteViewModel : BaseViewModel
    {
        private readonly IClienteService _clienteService;
        private Cliente cliente { get; set; } = new Cliente();
        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                PrimeiroNome = value.Name;
                UltimoNome = value.LastName;
                Endereco = value.Adress;
                Idade = Convert.ToString(value.Age);
                OnPropertyChanged(nameof(Cliente));
            }
        }
        private string primeiroNome = "";
        public string PrimeiroNome
        {
            get
            {
                return primeiroNome;
            }
            set
            {
                primeiroNome = value;
                OnPropertyChanged(nameof(PrimeiroNome));
            }
        }

        private string ultimoNome = "";
        public string UltimoNome
        {
            get
            {
                return ultimoNome;
            }
            set
            {
                ultimoNome = value;
                OnPropertyChanged(nameof(UltimoNome));
            }
        }

        private string idade = "";
        public string Idade
        {
            get
            {
                return idade;
            }
            set
            {
                string idadeFormatada = !string.IsNullOrEmpty(value) ? Regex.Replace(value, "[^0-9]", string.Empty) : "";
                idade = idadeFormatada;
                OnPropertyChanged(nameof(Idade));
            }
        }

        private string endereco = "";
        public string Endereco
        {
            get
            {
                return endereco;
            }
            set
            {
                endereco = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
        public ICommand ComandoEditarCliente { get; set; }
        public ICommand ComandoVoltar { get; set; }
        public EditarClienteViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
            ComandoEditarCliente = new Command(EditarCliente);
            ComandoVoltar = new Command(() => Shell.Current.Navigation.PopAsync());
        }

        private async void EditarCliente()
        {
            var clienteNovo = new Cliente();
            if (await clienteNovo.ValidarCliente(primeiroNome, ultimoNome, idade, endereco))
            {
                clienteNovo.Name = primeiroNome;
                clienteNovo.LastName = ultimoNome;
                clienteNovo.Age = Convert.ToInt32(idade);
                clienteNovo.Adress = endereco;

                var sucesso = _clienteService.EditarCliente(Cliente, clienteNovo);
                if (sucesso)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alerta", "Falha ao editar cadastro.", "OK");
                }
            }
        }

    }
}
