using System;
using System.Collections.Generic;
using LocadoraVHS.Interfaces;
using System.IO;

namespace LocadoraVHS
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{
        private List<Filme> listaFilme = new List<Filme>();
		public void Atualiza(int id, Filme objeto)
		{
			listaFilme[id] = objeto;
		}


		public void Insere(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme RetornaPorId(int id)
		{
			return listaFilme[id];
		}
        
    	public void GravarEmArquivo()
        {
            using (StreamWriter sw = new StreamWriter("RepistórioDeFilmes.csv"))
            {
                foreach (Filme filme in listaFilme)
                {
                    sw.WriteLine(filme.RetornaStringCSV());
                }
            }
        }

		public void LerDeArquivo()
		{
			if(File.Exists("RepistórioDeFilmes.csv"))
			{
				string line = "";
				using (StreamReader sr = new StreamReader("RepistórioDeFilmes.csv"))
				{
					while ((line = sr.ReadLine()) != null)
					{
						string[] campos = line.Split(',');
						Filme filme = new Filme(id:int.Parse(campos[0]), genero:Enum.Parse<Genero>(campos[3]), titulo:campos[1], descricao:campos[2], ano:int.Parse(campos[4]), filmeStatus:Enum.Parse<FilmeStatus>(campos[5]), idClienteTomador:int.Parse(campos[6]));
						Insere(filme);
					}
				}
			}
			
		}
    }
}