using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
       public void Cadastrar(Usuarios usuario)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Usuarios.Include("Usuarios").ToList();
            }
            return Listar();
        }
    }
}
