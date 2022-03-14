using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter.webapi.Models;


namespace Chapter.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
