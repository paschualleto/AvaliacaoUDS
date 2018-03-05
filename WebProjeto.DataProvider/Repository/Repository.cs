using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjeto.DataProvider.Context;
using WebProjeto.DataProvider.Models;

namespace WebProjeto.DataProvider.Repository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private WebProjetoContext context;

        public Repository()
        {
            context = new WebProjetoContext();
        }

        public bool Atualizar(T entity)
        {
            try
            {
                object TEntity = entity;
                context.Entry(TEntity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e) { }

            return true;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ICollection<T> Localizar()
        {
            return (context.Set(typeof(T)) as IEnumerable<T>).ToList();
        }

        public T LocalizarPorId(T entity)
        {
            return (T)context.Set(typeof(T)).Find(entity.Id);
        }

        public bool Remover(T entity)
        {
            try
            {
                entity = (T)context.Set(typeof(T)).Find(entity.Id);
                context.Set(typeof(T)).Remove(entity);
                context.SaveChanges();
            }
            catch (Exception e) {
               
            }
            return true;
        }

        public bool Salvar(T entity)
        {
            try
            {
                context.Set(typeof(T)).Add(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
            }
            return true;
        }
    }
}
