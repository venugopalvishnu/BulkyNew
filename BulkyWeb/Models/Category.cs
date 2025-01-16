using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,200)]
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public Category() { }
        
        public string Discription {  get; set; }
    }
}
