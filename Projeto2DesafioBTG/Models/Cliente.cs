using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2DesafioBTG.Models
{
    public class Cliente
    {
        public  string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }

        public async Task<bool> ValidarCliente(string primeiroNome,string ultimoNome,string idade,string endereco)
        {
            var conversaoValida = int.TryParse(idade, out var idadeInt);
            if (string.IsNullOrEmpty(primeiroNome))
            {
                await Shell.Current.DisplayAlert("Alerta", "Por gentileza preencher o primeiro nome.", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(ultimoNome))
            {
                await Shell.Current.DisplayAlert("Alerta", "Por gentileza preencher o último nome.", "OK");
                return false;
            }
            else if (!conversaoValida || idadeInt <= 0 || idadeInt > 120)
            {
                await Shell.Current.DisplayAlert("Alerta", "Idade inválida.", "OK");
                return false;
            }
            else if (string.IsNullOrEmpty(endereco))
            {
                await Shell.Current.DisplayAlert("Alerta", "Por gentileza preencher o endereço.", "OK");
                return false;
            }
            return true;
        }
    }
}
