using System;

namespace LocadoraVHS
{
    public class Filme : EntidadeBase
    {
        // Atributos
		private Genero Genero { get; set; }
		private FilmeStatus FilmeStatus { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}
		private int IdClienteTomador { get; set; }

        // Métodos
		public Filme(int id, Genero genero, string titulo, string descricao, int ano, FilmeStatus filmeStatus)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
			this.FilmeStatus = filmeStatus;
			this.IdClienteTomador = -1;// -1 quer dizer que o filme não está alugado
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
			retorno += "Status: " + this.FilmeStatus;
			if(this.FilmeStatus == FilmeStatus.Alugado)
			{
				retorno += $" pelo cliente: {this.IdClienteTomador}";
			}
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }

		public void MudarStatus(FilmeStatus filmeStatus)
		{
			this.FilmeStatus = filmeStatus;
		}

		public int RetornaTomador()
		{
			return this.IdClienteTomador;
		}

		public void Alugar(int clienteId)
		{
			this.IdClienteTomador = clienteId;
			this.FilmeStatus = FilmeStatus.Alugado;
		}

		public void Devolver()
		{
			this.IdClienteTomador = -1;
			this.FilmeStatus = FilmeStatus.EmEspera;
		}

		public void Disponibilizar()
		{
			this.FilmeStatus = FilmeStatus.Disponivel;
		}

		public FilmeStatus RetornaStatus()
		{
			return this.FilmeStatus;
		}
    }
}