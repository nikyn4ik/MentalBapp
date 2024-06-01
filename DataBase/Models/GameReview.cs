using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class GameReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public int GameId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("GameId")]
        public TherapeuticG TherapeuticGame { get; set; }
    }
}
