using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProjectAPITest.Domains;

namespace ProjectAPITest.Interface
{
    public interface IProductsRepository
    {

        /// <summary>
        /// Obtém uma lista de todos os produtos.
        /// </summary>
        /// <returns>Uma lista de objetos do tipo Products.</returns>
        public List<Products> Get();

        /// <summary>
        /// Obtém um produto específico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>O objeto Products correspondente ao ID fornecido.</returns>
        public Products GetById(Guid id);

        /// <summary>
        /// Adiciona um novo produto ao banco de dados.
        /// </summary>
        /// <param name="product">O objeto Products a ser adicionado.</param>
        /// <returns>O objeto Products adicionado.</returns>
        public void Post(Products product);

        /// <summary>
        /// Atualiza um produto existente no banco de dados.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="product">O objeto Products com os dados atualizados.</param>
        /// <returns>O objeto Products atualizado.</returns>
        public void Put(Guid id, Products product);

        /// <summary>
        /// Remove um produto do banco de dados.
        /// </summary>
        /// <param name="id">O ID do produto a ser removido.</param>
        public void Delete(Guid id);
    }
}
