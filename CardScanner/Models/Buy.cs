using System.ComponentModel.DataAnnotations;

namespace CardScanner.Models.ProductViewModels
{
    public class Buy
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal MaxPrice { get; set; }
    }

}
