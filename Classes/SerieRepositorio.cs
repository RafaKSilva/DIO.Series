using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> listaSerie =  new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
           return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

        public int QuantidadeDeRegistros()
        {
             return listaSerie.Count;
        }
    }
}