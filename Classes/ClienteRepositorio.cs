using System;
using System.Collections.Generic;
using LocadoraVHS.Interfaces;

namespace LocadoraVHS
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        private List<Cliente> listaCliente = new List<Cliente>();
        public void Atualiza(int id, Cliente objeto)
        {
            listaCliente[id] = objeto;
        }

        
        public void Exclui(int id)
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
    }
}