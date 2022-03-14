using System;
using System.Collections.Generic;
using System.Text;
using Moq;



namespace TestXunit.Controllers
{
    internal class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retornar_UsuarioInvalido()
        {
            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup

        }
    }
}
