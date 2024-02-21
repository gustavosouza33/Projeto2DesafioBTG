using Projeto2DesafioBTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2DesafioBTG.Interfaces
{
    public interface IClienteService
    {
        bool AdicionarCliente(Cliente cliente);
        bool EditarCliente(Cliente clienteAntigo, Cliente clienteNovo);
        bool ExcluirCliente(Cliente cliente);
    }
}
