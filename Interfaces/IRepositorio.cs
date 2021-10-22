using System.Collections.Generic;

namespace LocadoraVHS.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);              
        void Atualiza(int id, T entidade);
        int ProximoId();
        void GravarEmArquivo();
    }
}