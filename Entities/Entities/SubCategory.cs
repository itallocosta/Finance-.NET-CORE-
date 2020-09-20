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
 *     - SubCategoria (Ex: Categoria: Receitas - SubCategoria: Freelas, Categoria: Fixo - SubCategoria: Presta��es)
 *         - Categoria (Ex: Receitas, Fixo, Vari�veis)
 *     - BankAccount
 */