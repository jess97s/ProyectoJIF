using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioClienteF
    {
        accesoDatosClienteF ac = new accesoDatosClienteF();

        public int insertarClienteF(ClienteF cl)
        {
            return ac.insertarClienteF(cl);
        }
        public List<ClienteF> ListarClientes()
        {
            return ac.ListarClientes();
        }
        public int EditarCliente(ClienteF clF)
        { 
            return ac.EditarCliente(clF);
        }
       public int EliminarCliente(int idCliente)
       {
            return ac.EliminarCliente(idCliente);
       }
       public ClienteF BuscarClienteXcodigo(int idcliente)
       {
           return ac.BuscarClienteXcodigo(idcliente);
       }
       public List<ClienteF> BuscaClienteDatos(String dato)
       {
           return ac.BuscaClienteDatos(dato);
       }
    }
}
