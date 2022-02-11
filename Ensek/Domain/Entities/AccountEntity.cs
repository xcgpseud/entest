using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class AccountEntity
    {
        [Key]
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
