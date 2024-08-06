using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPITest.Domains
{
    [Table("Product")]
    public class Products
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        /// <remarks>
        /// Esta propriedade é a chave primária da entidade e é gerada automaticamente pelo banco de dados.
        /// </remarks>
        [Key] // Marca esta propriedade como a chave primária da entidade.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que o valor é gerado pelo banco de dados (identidade).
        public Guid IdProduct { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        /// <remarks>
        /// Esta propriedade é armazenada como uma string com comprimento máximo de 100 caracteres.
        /// </remarks>
        [Column(TypeName = "VARCHAR(100)")] // Define o tipo de coluna no banco de dados como VARCHAR com comprimento máximo de 100 caracteres.
        [Required(ErrorMessage = "Nome do Produto é Obrigatório.")]
        public string Name { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        /// <remarks>
        /// Esta propriedade é armazenada como um decimal com até 18 dígitos no total e 2 dígitos após o ponto decimal.
        /// </remarks>
        [Column(TypeName = "decimal(18,2)")] // Define o tipo de coluna no banco de dados como decimal com precisão 18 e escala 2.
        [Required(ErrorMessage = "Preço do produto é obrigatório.")]
        public decimal Price { get; set; }
    }
}
