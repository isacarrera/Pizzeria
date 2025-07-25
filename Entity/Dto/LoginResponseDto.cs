using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
    }
}
