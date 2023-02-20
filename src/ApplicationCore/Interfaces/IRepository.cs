using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T:BaseEntity //Ancak BaseEntityden miras almış classları kullanabilirsin
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync(); // Tümünü listele
        Task<List<T>> GetAllAsync(ISpecification<T> specification); 
        Task<T> AddAsync(T entity); //Ekle. Burada ki T, id'yi tekrar çağırabilmek için döndürüyoruz.
        Task UpdateAsync(T entity); //Güncelle
        Task DeleteAsync(T entity); //Sil
        Task<int> CountAsync(ISpecification<T>specification);
        Task<T> FirstAsync(ISpecification<T>specification);
        Task<T?>FirtOrDefaultAsync(ISpecification<T>specification);


    }
}
