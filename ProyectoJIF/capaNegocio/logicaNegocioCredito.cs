using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidades;

namespace capaNegocio
{
    public class logicaNegocioCredito
    {
        accesoDatosCredito acr = new accesoDatosCredito();
        public int insertarCredito(Credito cr)
        {
            return acr.insertarCredito(cr);
        }
        public List<Credito> ListarCredito()
        {
            return acr.ListarCredito();
        }
        public int EditarCredito(Credito crt)
        {
            return acr.EditarCredito(crt);
        }
        public int EliminarCredito(int id_credito)
        {
            return acr.EliminarCredito(id_credito);
        }
        public Credito BuscarCreditoXcodigo(int idcred)
        {
            return acr.BuscarCreditoXcodigo(idcred);
        }
        public List<Credito> BuscaCreditoDatos(String dato)
        {
            return acr.BuscaCreditoDatos(dato);
        }
    }
}
