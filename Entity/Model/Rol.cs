using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con usuarios
        public ICollection<User> Users { get; set; }
    }
}
