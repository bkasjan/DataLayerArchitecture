using System.Threading.Tasks;

namespace DataMapper.DataMappers.Interfaces
{
    public interface IDataMapper<T>
    {
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
