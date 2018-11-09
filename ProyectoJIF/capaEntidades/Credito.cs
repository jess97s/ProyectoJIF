using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Credito
    {
        public int id_credito { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_cancelacion { get; set; }
        public float monto_total { get; set; }        
        public string estado { get; set; }
        public int idCliente { get; set; }
    }
}
