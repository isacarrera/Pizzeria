using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entity.Dto
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PizzaId { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; } = null!;
    }
}
