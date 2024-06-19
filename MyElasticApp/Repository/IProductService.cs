using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> SearchAsync(string query);
}