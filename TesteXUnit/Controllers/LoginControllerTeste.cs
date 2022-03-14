using chapter.webapi.Controllers;
using chapter.webapi.Models;
using chapter.webapi.ViewModels;
using Chapter.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Xunit;

namespace TestXunit.Controllers
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retornar_UsuarioInvalido()
        {
            //Pré-Condição/Arrange
            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosUsuario =  new LoginViewModel();
            dadosUsuario.Email = "email@email.com";
            dadosUsuario.Senha = "1234";

            var controller = new LoginController(repositorioFalso.Object);

            //Procedimento/Act
            var resultado = controller.Login(dadosUsuario);

            //Resultado Esperado/Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void LoginController_Retornar_Usuario()
        {
            //Pré-Condição/Arrange
            string issuervalidacao = "chapter.webApi";

            Usuario usuarioFake = new Usuario();
            usuarioFake.Email = "email@email.com";
            usuarioFake.Senha = "1234";

            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioFake);

            var controller = new LoginController(repositorioFalso.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.Email = "email.@email.com";
            dadosUsuario.Senha = "1234";

            //Procedimento/Act
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            var token = resultado.Value.ToString().Split(' ')[3];

            var jstHandler = new JwtSecurityTokenHandler();
            var jwtToken = jstHandler.ReadJwtToken(token);


            //Resultado Esperado/Assert
            Assert.Equal(issuervalidacao, jwtToken.Issuer);
        }

        
    }
}
