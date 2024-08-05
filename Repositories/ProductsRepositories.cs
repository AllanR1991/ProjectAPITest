using Microsoft.EntityFrameworkCore;
using ProjectAPITest.Context;
using ProjectAPITest.Domains;
using ProjectAPITest.Interface;

namespace ProjectAPITest.Repositories
{
    public class ProductsRepositories : IProductsRepository
    {
        ProjectApiContextContext _context = new ProjectApiContextContext();
        public void Delete(Guid id)
        {
            Products? productsFind = _context.Products.FirstOrDefault(product => product.IdProduct == id);
            
            if (productsFind != null)
            {
                _context.Products.Remove(productsFind);
            }

            _context.SaveChanges();
        }

        public List<Products> Get()
        {
            return _context.Products.ToList();
        }

        public Products? GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(produto => produto.IdProduct == id);            
        }

        public Products Post(Products product)
        {
            throw new NotImplementedException();
        }

        public Products Put(Guid id, Products product)
        {
            throw new NotImplementedException();
        }
    }
}
