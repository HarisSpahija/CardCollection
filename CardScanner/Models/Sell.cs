using System.ComponentModel.DataAnnotations;

namespace CardScanner.Models.ProductViewModels
{
    public class Sell
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
