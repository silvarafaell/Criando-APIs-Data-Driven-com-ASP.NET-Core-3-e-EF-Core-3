using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "O campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, 999999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Invalida")]
        public int CategoriaId { get; set; }

        //Propriedade de referencia
        public Category Category { get; set; }
    }
}