using System;
using System.Collections.Generic;

namespace LocadoraVHS
{
    public class Cliente : EntidadeBase
    {
        private string Nome { get; set; }
        private bool Banido { get; set; }
        private List<int> filmesEmPosse = new List<int>();

        public Cliente(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Banido = false;
        }

        public List<int> ListarFilmesEmPosse(int id)
        {
            return filmesEmPosse;
        }

        public void Banir()
        {
            this.Banido = true;
        }

        public bool retornaBanido()
		{
			return this.Banido;
		}

        public int retornaId()
		{
			return this.Id;
		}

        public string retornaNome()
		{
			return this.Nome;
		}

        public void Alugar(int filmeId)
        {
            filmesEmPosse.Add(filmeId);
        }

        public void Devolver(int filmeId)
        {
            filmesEmPosse.Remove(filmeId);
        }
    }
    
}