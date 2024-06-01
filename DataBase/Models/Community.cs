using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Community
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommunityId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime CreationDate { get; set; } = DateTime.UtcNow;
            public ICollection<User> Members { get; set; }
        }
}