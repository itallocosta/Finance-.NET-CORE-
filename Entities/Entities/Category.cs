using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("Category")]
    public class Category: Base
    {
        [EnumDataType(typeof(CategoryTypeEnum))]
        public CategoryTypeEnum CategoryType { get; set; }
    }
}