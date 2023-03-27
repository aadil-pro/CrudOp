using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public class Model
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="The value to send is required")]
        public decimal AmountToSend { get; set; }
        [Required(ErrorMessage ="The value to receive in Indian currency is required")]
        public decimal AmountReceived { get; set; }
        [Required(ErrorMessage ="The amount to send is required")]
        public string SenderName { get; set; } = null!;
        [Required(ErrorMessage ="The amount to be received is required")]
        public string ReceiverName { get; set; } = null!;
        [Required(ErrorMessage ="The purpose is required")]
        public string Purpose { get; set; } = null!;
    }
}
