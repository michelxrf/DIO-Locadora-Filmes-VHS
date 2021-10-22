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

        public Cliente(int id, string nome, bool banido, int[] filmesEmPosse_CSV)
        {
            this.Id = id;
            this.Nome = nome;
            this.Banido = banido;
            
            foreach(int filme in filmesEmPosse_CSV)
            {
                filmesEmPosse.Add(filme);
            }
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

        public string RetornaStringCSV()
        {
            string retorno = $"{this.Id},{this.Nome},{this.Banido}";
            if(this.filmesEmPosse.Count > 0)
            {
                foreach(int filmeId in this.filmesEmPosse)
                {
                    retorno += $",{filmeId}";
                }
            }
            return retorno;
        }
        
    }
    
}