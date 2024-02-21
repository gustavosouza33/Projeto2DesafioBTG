using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2DesafioBTG.Services
{
    internal class ClienteService : IClienteService
    {
        public bool AdicionarCliente(Cliente cliente)
        {
            var lista = App.ListaClientes;
            var item = lista.FirstOrDefault(x => x.Name.Equals(cliente.Name) && x.LastName.Equals(cliente.LastName) && x.Age.Equals(cliente.Age) && x.Adress.Equals(cliente.Adress));
            if (item == null)
            {
                lista.Add(cliente);
                App.ListaClientes = lista;
                return true;
            }
            return false;
        }

        public bool EditarCliente(Cliente clienteAntigo, Cliente clienteNovo)
        {
            var lista = App.ListaClientes;
            var item = lista.FirstOrDefault(x => x.Name.Equals(clienteAntigo.Name) && x.LastName.Equals(clienteAntigo.LastName) && x.Age.Equals(clienteAntigo.Age) && x.Adress.Equals(clienteAntigo.Adress));
            if (item != null)
            {
                lista[lista.IndexOf(item)] = clienteNovo;
                App.ListaClientes = lista;
                return true;
            }
            return false;
        }

        public bool ExcluirCliente(Cliente cliente)
        {
            var lista = App.ListaClientes;
            var item = lista.FirstOrDefault(x => x.Name.Equals(cliente.Name) && x.LastName.Equals(cliente.LastName) && x.Age.Equals(cliente.Age) && x.Adress.Equals(cliente.Adress));
            if (item != null)
            {
                lista.RemoveAt(lista.IndexOf(item));
                App.ListaClientes = lista;
                return true;
            }
            return false;
        }
    }
}
