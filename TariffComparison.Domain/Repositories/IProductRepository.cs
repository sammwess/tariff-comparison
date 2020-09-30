using System.Collections.Generic;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Return all the products
        /// </summary>
        /// <returns></returns>
        IList<Product> GetAll();

        /// <summary>
        /// Save new product
        /// </summary>
        /// <param name="product"></param>
        void Save(Product product);
    }
}