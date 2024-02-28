using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace AppMottu.Models
{
    public class Usuario
    {
        public int IdUsu { get; set; }
        public required string NomeUsu { get; set; }
        public required string CnpjUsu { get; set; }
        public DateTime DnUsu { get; set; }
        public required string CnhUsu { get; set; }
        public required string CnhTUsu { get; set; }
        public required string CnhUsuFoto { get; set; }

        private List<Usuario> usuarios = new List<Usuario>();


        public Usuario ConsultarCadUsu(int IdUsu)
        {
            // Encontrar o usuário com base no IdUsu e NomeUsu
            Usuario usuarioEncontrado = usuarios.FirstOrDefault(u => u.IdUsu == IdUsu);

            return usuarioEncontrado;
        }

        internal bool ValidarCNPJ(string cnpjUsu)
        {
            throw new NotImplementedException();
        }

        internal void CadastrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public class UsuService
        {

            public void CadastrarUsuario(Usuario usuario)
            {
               

                // _context.Entregadores.Add(usuario);
                //_context.SaveChanges();
            }

            public void AtualizarICNH(int IdUsu, string CnhUsuFoto)
            {
                // Lógica para atualizar imagem CNH
            }

            public static bool ValidarCNPJ(string cnpj)
            {
                // Remove caracteres não numéricos
                cnpj = Regex.Replace(cnpj, @"[^\d]", "");

                // Verifica se a string tem 14 caracteres
                if (cnpj.Length != 14)
                    return false;

                // Calcula o primeiro dígito verificador
                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += int.Parse(cnpj[i].ToString()) * (13 - i);
                }
                int remainder = sum % 11;
                int digit1 = remainder < 2 ? 0 : 11 - remainder;

                // Calcula o segundo dígito verificador
                sum = 0;
                for (int i = 0; i < 13; i++)
                {
                    sum += int.Parse(cnpj[i].ToString()) * (14 - i);
                }
                remainder = sum % 11;
                int digit2 = remainder < 2 ? 0 : 11 - remainder;

                // Verifica se os dígitos calculados são iguais aos dígitos informados
                return int.Parse(cnpj[12].ToString()) == digit1 && int.Parse(cnpj[13].ToString()) == digit2;
            }
        }
    }
}
