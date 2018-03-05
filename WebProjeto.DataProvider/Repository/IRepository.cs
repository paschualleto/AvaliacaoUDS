using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjeto.DataProvider.Models;

namespace WebProjeto.DataProvider.Repository
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        bool Salvar(T entity);
        bool Remover(T entity);
        ICollection<T> Localizar();
        T LocalizarPorId(T entity);
        bool Atualizar(T entity);
    }
}
