using System.Collections.Generic;
using LocadoraVHS.Interfaces;
using System.IO;

namespace LocadoraVHS
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        private List<Cliente> listaCliente = new List<Cliente>();
        public void Atualiza(int id, Cliente objeto)
        {
            listaCliente[id] = objeto;
        }

        
        public void Banir(int id)
        //Preferia mudar o nome do método para Banir, mas a Interface me restringe
        {
            listaCliente[id].Banir();
        }

        public void Insere(Cliente objeto)
        {
            listaCliente.Add(objeto);
        }

        public List<Cliente> Lista()
        {
            return listaCliente;
        }

        public int ProximoId()
        {
            return listaCliente.Count;
        }

        public Cliente RetornaPorId(int id)
        {
            return listaCliente[id];
        }

        public void GravarEmArquivo()
        {
            using (StreamWriter sw = new StreamWriter("RepistórioDeClientes.csv"))
            {
                foreach (Cliente cliente in listaCliente)
                {
                    sw.WriteLine(cliente.RetornaStringCSV());
                }
            }
        }
        public void LerDeArquivo()
		{
			string line = "";
            using (StreamReader sr = new StreamReader("RepistórioDeClientes.csv"))
            {
                while ((line = sr.ReadLine()) != null)
                {
					string[] campos = line.Split(',');
                    int[] filmesComCliente = new int[campos.Length - 3];
                    
                    for(int i = 3; i < campos.Length; i++)
                    {
                        filmesComCliente[i - 3] = int.Parse(campos[i]);
                    }
                    Cliente cliente = new Cliente(id:int.Parse(campos[0]), nome:campos[1], banido:bool.Parse(campos[2]), filmesEmPosse_CSV:filmesComCliente);
					Insere(cliente);
				}
            }
		}
    }
}