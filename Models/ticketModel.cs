using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Claro.Models
{
    [Table("Ticket")]
    public class ticketModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        public string CPF { get; set; }

        public string NameUser { get; set; }
        public string Description { get; set; }

       
        public string? IPlocal { get; set; }
    }
}
