using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TariffComparison.Domain.Entities;
using TariffComparison.Domain.Repositories;
using TariffComparison.Infra.Data;

namespace TariffComparison.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        public IList<Product> GetAll()
        {
            return _context
                .Products
                .Include(p => p.CalculationModel)
                .AsNoTracking()
                .ToList();
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
