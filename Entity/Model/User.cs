using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        // Rol relacionado
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        // Estado (opcional)
        public bool Activo { get; set; }
    }

}
