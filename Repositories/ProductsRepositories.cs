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

        public Products GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(produto => produto.IdProduct == id);            
        }

        public void Post(Products product)
        {

                _context.Products.Add(product);
                
                _context.SaveChanges() ;
                        
        }

        public void Put(Guid id, Products product)
        {
            Products productFind = _context.Products.FirstOrDefault(produto => produto.IdProduct == id);

            
            if (productFind != null)
            {
                productFind.Name = product.Name;
                productFind.Price = product.Price;

                
                
                _context.Products.Update(productFind);
                _context.SaveChanges();
            }
        }


    }
}
