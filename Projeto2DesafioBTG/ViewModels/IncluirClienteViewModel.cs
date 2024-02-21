using Microsoft.Extensions.DependencyInjection;
using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Linq;

namespace Projeto2DesafioBTG.ViewModels
{
    public class IncluirClienteViewModel : BaseViewModel
    {
        private readonly IClienteService _clienteService;

        private string primeiroNome;
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

        private string ultimoNome;
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

        private string idade;
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

        private string endereco;
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


        public ICommand ComandoAdicionar { get; set; }
        public ICommand ComandoVoltar { get; set; }

        public IncluirClienteViewModel(IClienteService clientService)
        {
            ComandoAdicionar = new Command(AdicionarCliente);
            ComandoVoltar = new Command(() => Shell.Current.Navigation.PopAsync());
            _clienteService = clientService;
        }

        private async void AdicionarCliente()
        {
            var cliente = new Cliente();
            if (await cliente.ValidarCliente(primeiroNome, ultimoNome, idade, endereco))
            {
                cliente.Name = primeiroNome;
                cliente.LastName = ultimoNome;
                cliente.Age = Convert.ToInt32(idade);
                cliente.Adress = endereco;

                var sucesso = _clienteService.AdicionarCliente(cliente);
                if (sucesso)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alerta", "Não é possível incluir cadastros duplicados.", "OK");
                }
            }
        }
        public void inicializaItens()
        {
            Endereco = string.Empty;
            UltimoNome = string.Empty;
            PrimeiroNome = string.Empty;
            Idade = string.Empty;
        }

    }
}
