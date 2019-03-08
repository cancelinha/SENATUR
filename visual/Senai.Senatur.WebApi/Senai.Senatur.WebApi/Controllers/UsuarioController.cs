using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try {
                
                    UsuarioRepository.Cadastrar(usuario);
                
                    return Ok( new { mensagem = "Usuario Cadastrado" });
            }
            catch(System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
              return Ok(UsuarioRepository.Listar());
               
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
    }
}