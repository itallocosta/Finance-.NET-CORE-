using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("SubCategory")]
    public class SubCategory: Base
    {
        public Category Category { get; set; }
    }
}




/*
 *
 * - Contas (pagar, receber), Receitas, Investimento
 *     - SubCategoria
 *         - Categoria
 *     - BankAccount
 */